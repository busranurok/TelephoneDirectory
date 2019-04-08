namespace TelephoneDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChanges2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Manager_UserId" });
            AlterColumn("dbo.Users", "Manager_UserId", c => c.Int());
            CreateIndex("dbo.Users", "Manager_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Manager_UserId" });
            AlterColumn("dbo.Users", "Manager_UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "Manager_UserId");
        }
    }
}
