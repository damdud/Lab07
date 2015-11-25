namespace UamTTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transfers", "DestinationAccount_Id", "dbo.Accounts");
            DropForeignKey("dbo.Transfers", "SourceAccount_Id", "dbo.Accounts");
            DropIndex("dbo.Transfers", new[] { "DestinationAccount_Id" });
            DropIndex("dbo.Transfers", new[] { "SourceAccount_Id" });
            AddColumn("dbo.BudgetTemplates", "Name", c => c.String());
            AddColumn("dbo.BudgetTemplates", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.BudgetTemplates", "DefaultName");
            DropColumn("dbo.BudgetTemplates", "DefaultDuration");
            DropColumn("dbo.Transfers", "DestinationAccount_Id");
            DropColumn("dbo.Transfers", "SourceAccount_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transfers", "SourceAccount_Id", c => c.Int());
            AddColumn("dbo.Transfers", "DestinationAccount_Id", c => c.Int());
            AddColumn("dbo.BudgetTemplates", "DefaultDuration", c => c.Int(nullable: false));
            AddColumn("dbo.BudgetTemplates", "DefaultName", c => c.String());
            DropColumn("dbo.BudgetTemplates", "Duration");
            DropColumn("dbo.BudgetTemplates", "Name");
            CreateIndex("dbo.Transfers", "SourceAccount_Id");
            CreateIndex("dbo.Transfers", "DestinationAccount_Id");
            AddForeignKey("dbo.Transfers", "SourceAccount_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Transfers", "DestinationAccount_Id", "dbo.Accounts", "Id");
        }
    }
}
