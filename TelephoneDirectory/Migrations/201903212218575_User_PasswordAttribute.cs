namespace TelephoneDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_PasswordAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
    }
}
