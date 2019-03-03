using SchoolApplication.DAL;
using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApplication.Controllers
{
    public class ModalidadeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Title = "Gerenciamento de Modalidades";
            return View(ModalidadeDAO.RetornaModalidades());
        }

        public ActionResult CadastrarModalidade()
        {
            ViewBag.Title = "Cadastrar Modalidade";
            return View();
        }

        [HttpPost] //
        public ActionResult CadastrarModalidade(Modalidade modalidade)
        {
            if (ModelState.IsValid)
            {
                if (ModalidadeDAO.CadastrarModalidade(modalidade))
                {
                    return RedirectToAction("Index", "Modalidade");
                }
                ModelState.AddModelError("", "Essa Modalidade ja esta cadastrada");

            }

            return View(modalidade);

        }

        public ActionResult Remover(int id)
        {
            Modalidade modalidade = ModalidadeDAO.BuscarModalidadePorId(id);
            ModalidadeDAO.RemoverModalidade(modalidade);
            return RedirectToAction("Index", "Modalidade");
        }

        public ActionResult AlterarModalidade(int id)
        {
            ViewBag.Title = "Alterar Modalidade";
            return View(ModalidadeDAO.BuscarModalidadePorId(id));
        }

        [HttpPost]
        public ActionResult AlterarModalidade(Modalidade modalidade)
        {
            ViewBag.Title = "Alterar Modalidade";
            if (ModelState.IsValid)
            {
                Modalidade modalidadeAux = ModalidadeDAO.BuscarModalidadePorId(modalidade.ModalidadeId);
                modalidadeAux.Nome = modalidade.Nome;
                modalidadeAux.Descricao = modalidade.Descricao;
                ModalidadeDAO.AlterarModalidade(modalidadeAux);
            }
            return RedirectToAction("Index", "Modalidade");
        }
    }
}