using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {
        private EscuelaDBContext context = new EscuelaDBContext();
        // GET: Aula
        public ActionResult Index()
        {
            return View("Index",context.Aulas.ToList());
        }

        public ActionResult Create()
        {
            Aula newAula = new Aula();
            return View("Register", newAula);
        }

        [HttpPost]
        public ActionResult Create (Aula aula)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", aula);
            }
            context.Aulas.Add(aula);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View("Detalle", aula);
        }

        public ActionResult Edit(string id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View("Modificar", aula);
        }

        [HttpPost]
        public ActionResult Edit(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aula).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Modificar", aula);
        }

        public ActionResult ListarPorEstado(string estado)
        {

            return View("Index", BuscarPorEstado(estado));
        }

        public ActionResult TraerPorNumero(string numero)
        {
            if (BuscaPorNumero(numero) == null)
            {
                return HttpNotFound();
            }
            return View("Details", BuscaPorNumero(numero));
        }

        #region metodos NonAction


        [NonAction]
        public List<Aula> BuscarPorEstado (string estado)
        {
            List<Aula> listXEstado = new List<Aula>();
            listXEstado = (from a in context.Aulas where a.Estado.ToLower() == estado.ToLower() select a).ToList();
            return listXEstado;
        }

        [NonAction]
        public Aula BuscaPorNumero(string numero)
        {
            Aula aulaXNumero = new Aula();
            aulaXNumero = (from a in context.Aulas where a.Numero.ToLower() == numero.ToLower() select a).SingleOrDefault();
            return aulaXNumero;
        }

        #endregion

    }
}