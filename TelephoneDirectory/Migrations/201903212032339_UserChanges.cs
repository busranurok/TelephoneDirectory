namespace TelephoneDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Manager_UserId" });
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "DepartmentDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Users", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Manager_UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "Manager_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Manager_UserId" });
            AlterColumn("dbo.Users", "Manager_UserId", c => c.Int());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "Lastname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Departments", "DepartmentDescription", c => c.String());
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String());
            CreateIndex("dbo.Users", "Manager_UserId");
        }
    }
}
