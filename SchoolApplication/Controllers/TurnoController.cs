using SchoolApplication.DAL;
using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApplication.Controllers
{
    public class TurnoController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Title = "Gerenciamento de Turnos";
            return View(TurnoDAO.RetornarTurnos());
        }

        public ActionResult CadastrarTurno()
        {
            ViewBag.Title = "Cadastrar Turno";
            return View();
        }

        [HttpPost] //
        public ActionResult CadastrarTurno(Turno turno)
        {
            if (ModelState.IsValid)
            {
                if (TurnoDAO.CadastrarTurno(turno))
                {
                    return RedirectToAction("Index", "Turno");
                }
                ModelState.AddModelError("", "Essa turno ja esta cadastrada");

            }

            return View(turno);
        }

        public ActionResult Remover(int id)
        {
            Turno turno = TurnoDAO.BuscarTurnoPorId(id);
            TurnoDAO.RemoverTurno(turno);
            return RedirectToAction("Index", "Turno");
        }

        public ActionResult AlterarTurno(int id)
        {
            ViewBag.Title = "Alterar Turno";
            return View(TurnoDAO.BuscarTurnoPorId(id));
        }

        [HttpPost]//corrigir
        public ActionResult AlterarTurno(Turno turno)
        {
            ViewBag.Title = "Alterar Turno";
            if (ModelState.IsValid)
            {
                Turno turnoAux = TurnoDAO.BuscarTurnoPorId(turno.TurnoId);
                turnoAux.Nome = turno.Nome;
                turnoAux.Descricao = turno.Descricao;
                TurnoDAO.AlterarTurno(turnoAux);
            }
            return RedirectToAction("Index", "Turno");
        }
    }


}
