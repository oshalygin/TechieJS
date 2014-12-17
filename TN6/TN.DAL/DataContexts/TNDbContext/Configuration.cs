

namespace TN.DAL.DataContexts.TNDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;



    internal sealed class Configuration : DbMigrationsConfiguration<TN.DAL.TNDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\TNDbContext";
        }

        protected override void Seed(TN.DAL.TNDbContext context)
        {
            
        }

        private void SeedMembership()
        {
    

        }
    }
}
