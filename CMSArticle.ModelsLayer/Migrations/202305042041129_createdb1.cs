namespace CMSArticle.ModelsLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.T_Article", "AdminId");
            AddForeignKey("dbo.T_Article", "AdminId", "dbo.T_Admin", "AdminId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Article", "AdminId", "dbo.T_Admin");
            DropIndex("dbo.T_Article", new[] { "AdminId" });
        }
    }
}
