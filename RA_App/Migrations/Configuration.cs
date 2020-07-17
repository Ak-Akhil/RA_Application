namespace RA_App.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RA_App.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RA_App.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "RA_App.Models.ApplicationDbContext";
        }

        protected override void Seed(RA_App.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new ApplicationRole { Name = "Admin" };
                var roles = new ApplicationRole { Name = "RA" };
                manager.Create(role);
                manager.Create(roles);
            }

            if (!context.Users.Any(u => u.UserName == "Admin@dut.ac.za"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "Admin@dut.ac.za", Emp_ContactNo = "12345678911", Email = "Admin@dut.ac.za",Emp_Name="Admin",Emp_Surname="Admin", Emp_IDNum="12345678911",  };
                userManager.Create(userToInsert, "vMSZ}rtj_+MBd7BZ");
                userManager.AddToRole(userToInsert.Id, "Admin");

            }



        }


    }
}
