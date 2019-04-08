namespace TelephoneDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAttributeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
