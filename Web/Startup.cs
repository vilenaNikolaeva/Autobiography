using Autobiography.Data;
using Autobiography.Data.Repositories;
using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Autobiography.Services;
using Autobiography.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Text;
using Web.ActionFilters;

namespace Web
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "My react app";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            // For Identity  
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AutobiographyDbContext>()
                .AddDefaultTokenProviders();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
                                  });
            });
            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>     
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
            //Add action filter
            services.AddScoped<ValidationFilterAttribute>();
            //services.AddControllers(config =>
            //{
            //    config.Filters.Add(new ActionFilterAttribute());
            //});
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            //Add context
            services.AddDbContext<AutobiographyDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            //Services
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<IExperienceService, ExperienceService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IUserImageService, UserImageService>();
            services.AddTransient<IUserResumeService, UserResumeService>();

            //Repositories
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEducationRepository, EducationRepository>();
            services.AddTransient<IExperienceRepository, ExperienceRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IUserResumeRepository, UserResumeRepository>();
            
            services.AddAutoMapper(typeof(Startup));
            //services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<AutobiographyDbContext>();
                    context.Database.EnsureCreated();
                }
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
