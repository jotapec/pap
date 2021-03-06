﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using SalaoIedaV4.Models;

namespace SalaoIedaV4.Controllers
{
    

    public class AgendaController : Controller
    {
        private Context db = new Context();

        public bool VerificaHorario(DateTime dtIni, DateTime dtFim)
        {
            
            var testeData = db.Agendas.Where(a=>DbFunctions.TruncateTime(a.dt_data_agendada) == dtIni.Date && ((a.dt_cancelamento >= dtIni && dtIni >= a.dt_data_agendada) || (a.dt_data_agendada >= dtIni && a.dt_cancelamento >= dtFim && dtFim  >= a.dt_data_agendada))).ToList();
            if (testeData.Any())
            {
                return true;
            }else
            {
                return false;
            }
        }

    // GET: Agenda
    public ActionResult Index()
        {
            return View(db.Agendas.ToList()); //apenas mostrar os campos com data maior que a data atual.
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            ViewBag.ClienteNome = new SelectList(db.Clientes, "idCliente", "desc_nome_cliente");
            ViewBag.TipoServ = new SelectList(db.Tipo_Servicos, "idTipos_Servico", "desc_tipo_servico");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAgenda,dt_agendamento,dt_data_agendada,desc_servico,tempo_estimado,cancelamento,dt_cancelamento,dt_atualizacao")] Agenda agenda,string ClienteNome, string TipoServ)
        {
            ViewBag.ClienteNome = new SelectList(db.Clientes, "idCliente", "desc_nome_cliente");
            ViewBag.TipoServ = new SelectList(db.Tipo_Servicos, "idTipos_Servico", "desc_tipo_servico");
            agenda.dt_cancelamento = agenda.dt_data_agendada.AddMinutes(agenda.tempo_estimado);
            if (VerificaHorario(agenda.dt_data_agendada,agenda.dt_cancelamento))
            {
                //TempData["alertMessage"] = "Horario indisponivel";
                ModelState.AddModelError("", "ATENÇÃO -- Horario indisponível ----");
                //return Content("<script language='javascript' type='text/javascript'>alert     ('Horario indisponivel');</script>");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    agenda.dt_agendamento = DateTime.Now;
                    agenda.dt_atualizacao = DateTime.Now;
                    int idCliente = Convert.ToInt32(ClienteNome);
                    int idTipos_Servico = Convert.ToInt32(TipoServ);
                    agenda.Cliente = db.Clientes.Find(idCliente);
                    agenda.Tipo_Servico = db.Tipo_Servicos.Find(idTipos_Servico);
                    db.Agendas.Add(agenda);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(agenda);


        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteNome = new SelectList(db.Clientes, "idCliente", "desc_nome_cliente");
            ViewBag.TipoServ = new SelectList(db.Tipo_Servicos, "idTipos_Servico", "desc_tipo_servico");
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAgenda,dt_agendamento,dt_data_agendada,desc_servico,tempo_estimado,cancelamento,dt_cancelamento,dt_atualizacao")] Agenda agenda, string ClienteNome, string TipoServ)
        {
            ViewBag.ClienteNome = new SelectList(db.Clientes, "idCliente", "desc_nome_cliente");
            ViewBag.TipoServ = new SelectList(db.Tipo_Servicos, "idTipos_Servico", "desc_tipo_servico");
            if (ModelState.IsValid)
            {
                
                agenda.dt_cancelamento = agenda.dt_data_agendada.AddMinutes(agenda.tempo_estimado);
                agenda.dt_agendamento = DateTime.Now;
                agenda.dt_atualizacao = DateTime.Now;
                int idCliente = Convert.ToInt32(ClienteNome);
                int idTipos_Servico = Convert.ToInt32(TipoServ);
                agenda.Cliente = db.Clientes.Find(idCliente);                
                agenda.Tipo_Servico = db.Tipo_Servicos.Find(idTipos_Servico);
                //db.Entry(agenda) = agenda;
                var actAgenda = db.Agendas.FirstOrDefault(o => o.idAgenda == agenda.idAgenda);
                

                actAgenda.Cliente = agenda.Cliente;

                actAgenda.Tipo_Servico = agenda.Tipo_Servico;
                actAgenda.dt_agendamento = agenda.dt_agendamento;
                actAgenda.dt_data_agendada = agenda.dt_data_agendada;
                actAgenda.desc_servico = agenda.desc_servico;
                actAgenda.tempo_estimado = agenda.tempo_estimado;
                actAgenda.cancelamento = agenda.cancelamento;
                actAgenda.dt_cancelamento = agenda.dt_cancelamento;
                actAgenda.dt_atualizacao = agenda.dt_atualizacao;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda agenda = db.Agendas.Find(id);
            db.Agendas.Remove(agenda);
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
