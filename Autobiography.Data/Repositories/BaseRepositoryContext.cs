namespace Autobiography.Data
{
    public abstract class BaseRepositoryContext
    {
        protected readonly AutobiographyDbContext context;

        public BaseRepositoryContext(AutobiographyDbContext context)
        {
            this.context = context;
        }
    }
}
