using System.Data.Entity.Migrations;
using CAN.SMS.Data.Contexts;

namespace CAN.SMS.Data.StudentTrackingMigration
{
    public class Configuration : DbMigrationsConfiguration<StudentTrackingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}