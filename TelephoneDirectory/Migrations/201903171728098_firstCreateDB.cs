namespace TelephoneDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstCreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentDescription = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lastname = c.String(),
                        Username = c.String(),
                        PhoneNumber = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Manager_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Manager_UserId)
                .Index(t => t.DepartmentId)
                .Index(t => t.Manager_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Manager_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Users", new[] { "Manager_UserId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropTable("dbo.Users");
            DropTable("dbo.Departments");
        }
    }
}
