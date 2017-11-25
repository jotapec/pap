using SalaoIedaV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalaoIedaV4.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report   03    var vendas = db.PedidoCabecalhos.Where(i => i.DataPedido >= dataInicial && i.DataPedido <= dataFinal).OrderBy(p=>p.PedidoCabId).ToList<PedidoCabecalho>();
        public class AgendaTipo
        {
            public string NomeTipoServico { get; set; }
            public int agendas { get; set; }
        }
        private Context dc= new Context();
        public ActionResult Index()
        {
            ViewBag.ClienteCount = dc.Clientes.Select(Cliente => Cliente.idCliente).Count();
            ViewBag.ServicoCount = dc.Servicos.Select(Servico => Servico.idServico).Count();
            ViewBag.AgendaMesCount = dc.Agendas.Where(a => a.dt_data_agendada.Month == DateTime.Now.Month && a.cancelamento == false).Count();
            ViewBag.AgendaTotalCount = dc.Agendas.Where(a => a.cancelamento == false).Count();
            ViewBag.AgendaMesTipoCount = dc.Agendas.Where(a => a.dt_data_agendada.Month == DateTime.Now.Month && a.cancelamento == false).GroupBy(a => a.Tipo_Servico.desc_tipo_servico).Select(x => new AgendaTipo {NomeTipoServico = x.Key, agendas = x.Count()} ).ToList();
            ViewBag.AgendaTotalTipoCount = dc.Agendas.GroupBy(a => a.Tipo_Servico.desc_tipo_servico).Select(x => new AgendaTipo { NomeTipoServico = x.Key, agendas = x.Count() }).ToList();
            ViewBag.ValorMesSum = dc.Pagamentos.Where(a => a.dt_pagamento.Month == DateTime.Now.Month).Select(x => x.vl_pago).Sum();
            ViewBag.ValorTotalSum = dc.Pagamentos.Select(x => x.vl_pago).Sum(); ;
            return View();
        }
        
        
    }
}