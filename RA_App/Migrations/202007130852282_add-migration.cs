namespace RA_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Emp_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Emp_Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Emp_IDNum", c => c.String());
            AddColumn("dbo.AspNetUsers", "Emp_ContactNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Emp_ContactNo");
            DropColumn("dbo.AspNetUsers", "Emp_IDNum");
            DropColumn("dbo.AspNetUsers", "Emp_Surname");
            DropColumn("dbo.AspNetUsers", "Emp_Name");
        }
    }
}
