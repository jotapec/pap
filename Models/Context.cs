using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SalaoIedaV4.Models
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Tipo_Servico> Tipo_Servicos { get; set; }
        public DbSet<Tipos_Pagamento> Tipos_Pagamentos { get; set; }

    }

}