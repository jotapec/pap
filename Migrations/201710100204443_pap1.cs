namespace SalaoIedaV4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pap1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        idAgenda = c.Int(nullable: false, identity: true),
                        dt_agendamento = c.DateTime(nullable: false),
                        dt_data_agendada = c.DateTime(nullable: false),
                        desc_servico = c.String(),
                        tempo_estimado = c.Int(nullable: false),
                        cancelamento = c.Boolean(nullable: false),
                        dt_cancelamento = c.DateTime(nullable: false),
                        dt_atualizacao = c.DateTime(nullable: false),
                        Cliente_idCliente = c.Int(),
                        Tipo_Servico_idTipos_Servico = c.Int(),
                    })
                .PrimaryKey(t => t.idAgenda)
                .ForeignKey("dbo.Clientes", t => t.Cliente_idCliente)
                .ForeignKey("dbo.Tipo_Servico", t => t.Tipo_Servico_idTipos_Servico)
                .Index(t => t.Cliente_idCliente)
                .Index(t => t.Tipo_Servico_idTipos_Servico);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        desc_nome_cliente = c.String(nullable: false),
                        data_cadastro = c.DateTime(nullable: false),
                        data_atualizacao = c.DateTime(nullable: false),
                        data_prox_servico = c.DateTime(nullable: false),
                        desc_email_cliente = c.String(nullable: false),
                        Telefone_idTelefone = c.Int(),
                    })
                .PrimaryKey(t => t.idCliente)
                .ForeignKey("dbo.Telefones", t => t.Telefone_idTelefone)
                .Index(t => t.Telefone_idTelefone);
            
            CreateTable(
                "dbo.Telefones",
                c => new
                    {
                        idTelefone = c.Int(nullable: false, identity: true),
                        num_tel_principal = c.Int(nullable: false),
                        num_tel_secundario = c.Int(nullable: false),
                        data_atualizacao_principal = c.DateTime(nullable: false),
                        data_atualizacao_secundario = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idTelefone);
            
            CreateTable(
                "dbo.Tipo_Servico",
                c => new
                    {
                        idTipos_Servico = c.Int(nullable: false, identity: true),
                        desc_tipo_servico = c.String(nullable: false),
                        dt_ini_vigencia_serv = c.DateTime(nullable: false),
                        dt_fim_vigencia_serv = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idTipos_Servico);
            
            CreateTable(
                "dbo.Pagamentos",
                c => new
                    {
                        idPagamentos = c.Int(nullable: false, identity: true),
                        dt_pagamento = c.DateTime(nullable: false),
                        vl_pago = c.Double(nullable: false),
                        vl_cobrado = c.Double(nullable: false),
                        status_pagamento = c.String(nullable: false),
                        Tipos_Pagamento_idTipos_pagamento = c.Int(),
                    })
                .PrimaryKey(t => t.idPagamentos)
                .ForeignKey("dbo.Tipos_Pagamento", t => t.Tipos_Pagamento_idTipos_pagamento)
                .Index(t => t.Tipos_Pagamento_idTipos_pagamento);
            
            CreateTable(
                "dbo.Tipos_Pagamento",
                c => new
                    {
                        idTipos_pagamento = c.Int(nullable: false, identity: true),
                        desc_tipo_pagamento = c.String(nullable: false),
                        desc_natureza_pagamento = c.String(nullable: false),
                        desc_canal_pagamento = c.String(nullable: false),
                        dt_ini_vigencia = c.DateTime(nullable: false),
                        dt_fim_vigencia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idTipos_pagamento);
            
            CreateTable(
                "dbo.Servicoes",
                c => new
                    {
                        idServico = c.Int(nullable: false, identity: true),
                        data_servico = c.DateTime(nullable: false),
                        desc_comentario_servico = c.String(),
                        img_foto_servico = c.String(),
                        Agenda_idAgenda = c.Int(),
                        Cliente_idCliente = c.Int(),
                        Pagamentos_idPagamentos = c.Int(),
                        Tipo_Servico_idTipos_Servico = c.Int(),
                    })
                .PrimaryKey(t => t.idServico)
                .ForeignKey("dbo.Agenda", t => t.Agenda_idAgenda)
                .ForeignKey("dbo.Clientes", t => t.Cliente_idCliente)
                .ForeignKey("dbo.Pagamentos", t => t.Pagamentos_idPagamentos)
                .ForeignKey("dbo.Tipo_Servico", t => t.Tipo_Servico_idTipos_Servico)
                .Index(t => t.Agenda_idAgenda)
                .Index(t => t.Cliente_idCliente)
                .Index(t => t.Pagamentos_idPagamentos)
                .Index(t => t.Tipo_Servico_idTipos_Servico);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicoes", "Tipo_Servico_idTipos_Servico", "dbo.Tipo_Servico");
            DropForeignKey("dbo.Servicoes", "Pagamentos_idPagamentos", "dbo.Pagamentos");
            DropForeignKey("dbo.Servicoes", "Cliente_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.Servicoes", "Agenda_idAgenda", "dbo.Agenda");
            DropForeignKey("dbo.Pagamentos", "Tipos_Pagamento_idTipos_pagamento", "dbo.Tipos_Pagamento");
            DropForeignKey("dbo.Agenda", "Tipo_Servico_idTipos_Servico", "dbo.Tipo_Servico");
            DropForeignKey("dbo.Agenda", "Cliente_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Telefone_idTelefone", "dbo.Telefones");
            DropIndex("dbo.Servicoes", new[] { "Tipo_Servico_idTipos_Servico" });
            DropIndex("dbo.Servicoes", new[] { "Pagamentos_idPagamentos" });
            DropIndex("dbo.Servicoes", new[] { "Cliente_idCliente" });
            DropIndex("dbo.Servicoes", new[] { "Agenda_idAgenda" });
            DropIndex("dbo.Pagamentos", new[] { "Tipos_Pagamento_idTipos_pagamento" });
            DropIndex("dbo.Clientes", new[] { "Telefone_idTelefone" });
            DropIndex("dbo.Agenda", new[] { "Tipo_Servico_idTipos_Servico" });
            DropIndex("dbo.Agenda", new[] { "Cliente_idCliente" });
            DropTable("dbo.Servicoes");
            DropTable("dbo.Tipos_Pagamento");
            DropTable("dbo.Pagamentos");
            DropTable("dbo.Tipo_Servico");
            DropTable("dbo.Telefones");
            DropTable("dbo.Clientes");
            DropTable("dbo.Agenda");
        }
    }
}
