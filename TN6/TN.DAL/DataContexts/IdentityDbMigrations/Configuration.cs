using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TN.Models;


namespace TN.DAL.DataContexts.IdentityDbMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TN.DAL.IdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\IdentityDbMigrations";
        }

        protected override void Seed(TN.DAL.IdentityContext context)
        {
            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole { Name = "Admin" };
                var memberRole = new IdentityRole { Name = "Member" };
                
                manager.Create(adminRole);
                manager.Create(memberRole);

            }



            if (!context.Users.Any(x => x.UserName == "oshalygin"))
            {
                var store = new UserStore<CustomUser>(context);
                var manager = new UserManager<CustomUser>(store);
             
                
                var olegUser = new CustomUser
                {
                    UserName = "oshalygin",
                    FirstName = "Oleg",
                    LastName = "Shalygin",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1985, 11, 27),
                    State = "CA",
                    EmailAddress = "oshalygin@gmail.com",
                    Phone = "213-245-7636",
                    AcceptsPrivacyPolicy = true,
                    AcceptsTerms = true,
                    Company = "TechieJS",
                    Title = "Developer",
                    Description = "Developer and Founder of TechieJS  Learning web development and coding is a passion of mine",
                    PhotoPath = "/Content/img/user_default.png",
                    DateUserDetailsUpdated = DateTime.Now,

                };

                manager.Create(olegUser, "olegoleg");
                manager.AddToRole(olegUser.Id, "Admin");

                var carlotaUser = new CustomUser
                {
                    UserName = "cturcios",
                    FirstName = "Carlota",
                    LastName = "Turcios",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1986, 5, 19),
                    State = "CA",
                    EmailAddress = "cturcios86@gmail.com",
                    Phone = "818-770-9138",
                    AcceptsPrivacyPolicy = true,
                    AcceptsTerms = true,
                    Company = "Concord University",
                    Title = "Student",
                    Description = "Learning to become the best Dental Hygienist ever!!",
                    PhotoPath = "/Content/img/user_default.png",
                    DateUserDetailsUpdated = DateTime.Now,

                };

                manager.Create(carlotaUser, "pancho");
                manager.AddToRole(carlotaUser.Id, "Member");


            }




        }

    }
}
