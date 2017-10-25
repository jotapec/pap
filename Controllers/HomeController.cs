using SalaoIedaV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SalaoIedaV4.Controllers
{
    public class HomeController : Controller
    {
        private Context dc;
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            dc = new Context();
                var events = dc.Agendas.Include(a => a.Cliente)
                    .Include(a => a.Tipo_Servico)
                    .Include(a => a.Cliente.telefone);
                
                return new JsonResult { Data = events.ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}