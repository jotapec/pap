﻿using System;
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
    public class ServicosController : Controller
    {
        private Context db = new Context();

        // GET: Servicos
        public ActionResult Index()
        {
            return View(db.Servicos.ToList());
        }

        // GET: Servicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicos.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // GET: Servicos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteNome = new SelectList(db.Clientes, "idCliente", "desc_nome_cliente");
            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServico,data_servico,desc_comentario_servico,img_foto_servico")] Servico servico, HttpPostedFileBase img_foto, string ClienteNome)
        {
            if (ModelState.IsValid)
            {
                if (img_foto != null)
                {
                    ViewBag.ClienteNome = new SelectList(db.Clientes, "idCliente", "desc_nome_cliente");
                    String ImageName = System.IO.Path.GetFileName(img_foto.FileName);
                    String physicalPath = Server.MapPath("~/Images/" + ImageName);
                    img_foto.SaveAs(physicalPath);
                    servico.img_foto_servico = ImageName;
                    servico.data_servico = DateTime.Now;
                    int idCliente = Convert.ToInt32(ClienteNome);
                    servico.Cliente = db.Clientes.Find(idCliente);
                    db.Servicos.Add(servico);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                    
            }

            return View(servico);
        }

        // GET: Servicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicos.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteNome = new SelectList(db.Clientes, "idCliente", "desc_nome_cliente");
            return View(servico);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServico,data_servico,desc_comentario_servico,img_foto_servico")] Servico servico, HttpPostedFileBase img_foto, string ClienteNome)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ClienteNome = new SelectList(db.Clientes, "idCliente", "desc_nome_cliente");
                String ImageName = System.IO.Path.GetFileName(img_foto.FileName);
                String physicalPath = Server.MapPath("~/Images/" + ImageName);
                img_foto.SaveAs(physicalPath);
                servico.img_foto_servico = ImageName;
                servico.data_servico = DateTime.Now;
                int idCliente = Convert.ToInt32(ClienteNome);
                servico.Cliente = db.Clientes.Find(idCliente);
                db.Entry(servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servico);
        }

        // GET: Servicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicos.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servico servico = db.Servicos.Find(id);
            db.Servicos.Remove(servico);
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
