using Newtonsoft.Json.Linq;
using SchoolApplication.DAL;
using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolApplication.Controllers
{
     // [authorize/esse controle´somente consegue ser acessado com alguem que estiver logado

    public class CategoriaController : Controller
    {
        // GET: Categoria

        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Title = "Gerenciamento de Categorias";
            return View(CategoriaDAO.RetornaCategoria());
        }

        public ActionResult CadastrarCategoria()
        {
            ViewBag.Title = "Cadastrar Categoria";
            return View();
        }

        [HttpPost] //
        public ActionResult Cadastrarcategoria(Categoria categoria)
        {

            var response = Request["g-recaptcha-response"];
            string secretKey = "6LcEknwUAAAAAOIxGmXlQNAn22T7uFs8zUZ4UCuI";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";


            if (status == true)
            {
                if (ModelState.IsValid)
                {
                    if (CategoriaDAO.CadastrarCategoria(categoria))
                    {
                        return RedirectToAction("Index", "Categoria");
                    }
                    ModelState.AddModelError("", "Essa categoria ja esta cadastrada");

                }
            }
            return View(categoria);

        }

        public ActionResult Remover(int id)
        {
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            CategoriaDAO.RemoverCategoria(categoria);
            return RedirectToAction("Index", "Categoria");
        }

        public ActionResult AlterarCategoria(int id)
        {
            ViewBag.Title = "Alterar Categoria";
            return View(CategoriaDAO.BuscarCategoriaPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarCategoria(Categoria categoria)
        {
            ViewBag.Title = "Alterar Categoria";
            if (ModelState.IsValid)
            {
                Categoria categoriaAux = CategoriaDAO.BuscarCategoriaPorId(categoria.CategoriaId);
                categoriaAux.Nome = categoria.Nome;
                categoriaAux.Descricao = categoria.Descricao;
                CategoriaDAO.AlterarCategoria(categoriaAux);
            }
            return RedirectToAction("Index", "Categoria");
        }

    }
}