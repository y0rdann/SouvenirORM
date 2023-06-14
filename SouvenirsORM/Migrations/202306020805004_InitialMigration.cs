namespace SouvenirsORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SouvenirTypes", "SouvenirType_Id", "dbo.SouvenirTypes");
            DropIndex("dbo.SouvenirTypes", new[] { "SouvenirType_Id" });
            DropColumn("dbo.SouvenirTypes", "SouvenirType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SouvenirTypes", "SouvenirType_Id", c => c.Int());
            CreateIndex("dbo.SouvenirTypes", "SouvenirType_Id");
            AddForeignKey("dbo.SouvenirTypes", "SouvenirType_Id", "dbo.SouvenirTypes", "Id");
        }
    }
}
