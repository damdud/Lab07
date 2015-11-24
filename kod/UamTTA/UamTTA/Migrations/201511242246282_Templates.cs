using System.Data.Entity.Migrations;

namespace UamTTA.Migrations
{
    public partial class Templates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetTemplates",
                c => new
                {
                    Id = c.Int(false, true),
                    DefaultName = c.String(),
                    DefaultDuration = c.Int(false)
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.BudgetTemplates");
        }
    }
}