using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ActionFilters;
using Web.ViewModels;

namespace Web.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserResume : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserResume(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetUserInfoById(string id)
        {
            var userInfo = await this._userService.GetUserInfoById(id);

            if (userInfo[0].IsItPublic)
            {
                return Ok(userInfo);
            }
            return NotFound();
         
        }
    }
}
