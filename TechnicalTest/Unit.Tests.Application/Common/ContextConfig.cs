using TestSupport.EfHelpers;

namespace Unit.Tests.Application.Common
{
    public static class ContextConfig
    {
        public static TContext LoadContextInMemory<TContext>() where TContext : DbContext
        {
            DbContextOptions<TContext> options = SqliteInMemory.CreateOptions<TContext>();
            var context = (TContext?)Activator.CreateInstance(typeof(TContext), options);

            if (context == null)
                throw new NullReferenceException(nameof(context));

            return context;
        }

        public static void InitializeDb<TContext>(TContext? seedContext) where TContext : DbContext
        {
            if (seedContext != null)
            {
                seedContext.Database.EnsureDeleted();
                seedContext.Database.EnsureCreated();
                seedContext.SaveChanges();
            }
        }
    }
}
