using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CAN.SMS.Data.Contexts
{
    public class BaseDbContext<TContext, TConfiguration> : DbContext where TContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private static string _nameOrConnectionString = typeof(TContext).Name;

        public BaseDbContext() : base(_nameOrConnectionString)
        {
        }

        public BaseDbContext(string connetionString) : base(connetionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TContext, TConfiguration>());
            _nameOrConnectionString = connetionString;
        }
    }
}