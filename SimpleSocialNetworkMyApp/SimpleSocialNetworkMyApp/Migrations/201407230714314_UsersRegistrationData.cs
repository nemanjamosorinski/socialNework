namespace SimpleSocialNetworkMyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersRegistrationData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRegistrations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRegistrations");
        }
    }
}
