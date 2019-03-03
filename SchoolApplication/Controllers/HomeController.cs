using Newtonsoft.Json.Linq;
using SchoolApplication.DAL;
using SchoolApplication.Models;
using SchoolApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolApplication.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(int? id)
        {

        


            //    if (Request.IsAuthenticated)
            //{
            //}
            //else
            //{

            //}

            //dropdowm
            //ViewBag.Categorias = new SelectList(
            // CategoriaDAO.RetornaCategoria(), "CategoriaId", "Nome");

            ViewBag.Categorias = CategoriaDAO.RetornaCategoria();

            //  ViewBag.Modalidades = ModalidadeDAO.RetornaModalidades();

            if (id == null || id == 0)
            {

                return View(CursoDAO.RetornarCursos());
            }
            return View(CursoDAO.BuscarCursoPorCategoria(id));
        }

        public ActionResult DetalhesCurso(int? id)
        {
            ViewBag.Title = "Detalhe Curso";

            return View(CursoDAO.BuscarCursoPorId(id));
        }

        [Authorize]
        public ActionResult Inscricao(int? id)
        {
            ViewBag.Title = "Cadastrar Usuario";
            ViewBag.Usuario = UsuarioDAO.BuscarUsarioPorEmail(User.Identity.Name);


            return View(CursoDAO.BuscarCursoPorId(id));
        }

        [HttpPost]
        public ActionResult Inscricao(int id)
        {

            ViewBag.Title = "Inscricao da Matricula";
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LcEknwUAAAAAOIxGmXlQNAn22T7uFs8zUZ4UCuI";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";


            if (status == true)
            {

                Matricula matricula = new Matricula
                {
                    Usuario = UsuarioDAO.BuscarUsarioPorEmail(User.Identity.Name),
                    Curso = CursoDAO.BuscarCursoPorId(id)
                };
                if (ModelState.IsValid)
                {
                    // diminui a quantidade de vagas
                    if (Validar.QuantidadeCurso(matricula.Curso))
                    {

                        if (MatriculaDAO.RealizarMatricula(matricula))
                        {

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Matricula não realizada");

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Quantidade de vagas esgotadas");

                    }
                }
            }
            return View(CursoDAO.BuscarCursoPorId(id));

        }
        [Authorize(Roles = "Aluno")]
        public ActionResult MeusCursos()
        {
            Usuario usuario = new Usuario();
            usuario = UsuarioDAO.BuscarUsarioPorEmail(User.Identity.Name);

            return View(MatriculaDAO.RetornarCursosPorAluno(usuario.UsuarioId));
        }





    }
}