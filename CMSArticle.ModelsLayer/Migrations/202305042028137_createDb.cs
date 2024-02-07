namespace CMSArticle.ModelsLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Family = c.String(nullable: false, maxLength: 80),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 30),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.T_Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Content = c.String(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 50),
                        Like = c.Int(nullable: false),
                        Visit = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AdminId = c.Int(nullable: false),
                        category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.T_Category", t => t.category_CategoryId)
                .Index(t => t.category_CategoryId);
            
            CreateTable(
                "dbo.T_Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 80),
                        ImageName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.T_Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false, maxLength: 80),
                        Content = c.String(nullable: false, maxLength: 200),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        article_ArticleId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.T_Article", t => t.article_ArticleId)
                .Index(t => t.article_ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Comment", "article_ArticleId", "dbo.T_Article");
            DropForeignKey("dbo.T_Article", "category_CategoryId", "dbo.T_Category");
            DropIndex("dbo.T_Comment", new[] { "article_ArticleId" });
            DropIndex("dbo.T_Article", new[] { "category_CategoryId" });
            DropTable("dbo.T_Comment");
            DropTable("dbo.T_Category");
            DropTable("dbo.T_Article");
            DropTable("dbo.T_Admin");
        }
    }
}
