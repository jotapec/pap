using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalaoIedaV4.Models;

namespace SalaoIedaV4.Controllers
{
    public class Tipo_ServicoController : Controller
    {
        private Context db = new Context();

        // GET: Tipo_Servico
        public ActionResult Index()
        {
            return View(db.Tipo_Servicos.ToList());
        }

        // GET: Tipo_Servico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Servico tipo_Servico = db.Tipo_Servicos.Find(id);
            if (tipo_Servico == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Servico);
        }

        // GET: Tipo_Servico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Servico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipos_Servico,desc_tipo_servico,dt_ini_vigencia_serv,dt_fim_vigencia_serv")] Tipo_Servico tipo_Servico)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Servicos.Add(tipo_Servico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Servico);
        }

        // GET: Tipo_Servico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Servico tipo_Servico = db.Tipo_Servicos.Find(id);
            if (tipo_Servico == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Servico);
        }

        // POST: Tipo_Servico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipos_Servico,desc_tipo_servico,dt_ini_vigencia_serv,dt_fim_vigencia_serv")] Tipo_Servico tipo_Servico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Servico);
        }

        // GET: Tipo_Servico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Servico tipo_Servico = db.Tipo_Servicos.Find(id);
            if (tipo_Servico == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Servico);
        }

        // POST: Tipo_Servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Servico tipo_Servico = db.Tipo_Servicos.Find(id);
            db.Tipo_Servicos.Remove(tipo_Servico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
