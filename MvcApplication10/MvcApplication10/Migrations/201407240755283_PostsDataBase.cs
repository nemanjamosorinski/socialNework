namespace MvcApplication10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostsDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostContents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.Binary(),
                        ImageMimeType = c.String(),
                        TextPost = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostContents");
        }
    }
}
