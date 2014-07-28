namespace MvcApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageComment = c.String(),
                        ImageData = c.Binary(),
                        ImageMimoType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Class1");
        }
    }
}
