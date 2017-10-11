namespace SalaoIedaV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pap3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clientes", new[] { "Telefone_idTelefone" });
            CreateIndex("dbo.Clientes", "telefone_idTelefone");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "telefone_idTelefone" });
            CreateIndex("dbo.Clientes", "Telefone_idTelefone");
        }
    }
}
