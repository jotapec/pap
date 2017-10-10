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
    public class Tipos_PagamentoController : Controller
    {
        private Context db = new Context();

        // GET: Tipos_Pagamento
        public ActionResult Index()
        {
            return View(db.Tipos_Pagamentos.ToList());
        }

        // GET: Tipos_Pagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Pagamento tipos_Pagamento = db.Tipos_Pagamentos.Find(id);
            if (tipos_Pagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Pagamento);
        }

        // GET: Tipos_Pagamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipos_Pagamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipos_pagamento,desc_tipo_pagamento,desc_natureza_pagamento,desc_canal_pagamento,dt_ini_vigencia,dt_fim_vigencia")] Tipos_Pagamento tipos_Pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Tipos_Pagamentos.Add(tipos_Pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipos_Pagamento);
        }

        // GET: Tipos_Pagamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Pagamento tipos_Pagamento = db.Tipos_Pagamentos.Find(id);
            if (tipos_Pagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Pagamento);
        }

        // POST: Tipos_Pagamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipos_pagamento,desc_tipo_pagamento,desc_natureza_pagamento,desc_canal_pagamento,dt_ini_vigencia,dt_fim_vigencia")] Tipos_Pagamento tipos_Pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos_Pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos_Pagamento);
        }

        // GET: Tipos_Pagamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Pagamento tipos_Pagamento = db.Tipos_Pagamentos.Find(id);
            if (tipos_Pagamento == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Pagamento);
        }

        // POST: Tipos_Pagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos_Pagamento tipos_Pagamento = db.Tipos_Pagamentos.Find(id);
            db.Tipos_Pagamentos.Remove(tipos_Pagamento);
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
