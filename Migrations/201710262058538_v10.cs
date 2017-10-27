namespace SalaoIedaV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagamentos", "Agenda_idAgenda", c => c.Int());
            CreateIndex("dbo.Pagamentos", "Agenda_idAgenda");
            AddForeignKey("dbo.Pagamentos", "Agenda_idAgenda", "dbo.Agenda", "idAgenda");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagamentos", "Agenda_idAgenda", "dbo.Agenda");
            DropIndex("dbo.Pagamentos", new[] { "Agenda_idAgenda" });
            DropColumn("dbo.Pagamentos", "Agenda_idAgenda");
        }
    }
}
