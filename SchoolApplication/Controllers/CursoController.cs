using SchoolApplication.DAL;
using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SchoolApplication.Controllers
{
    public class CursoController : Controller
    {

        // GET: Curso
        [Authorize(Roles = "Adm")]
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Title = "Gerenciamento de Cursos";
            //alinhas isso
            // encontra o cara autenticado trazer as informacoes atraves de uma busca, por email, ou cpf
            //if (Request.IsAuthenticated)
            //{
            //    ViewBag.Aluno = User.Identity.Name;
            //}
            //else
            //{
            //    ViewBag.Aluno = "Não Autenticado";
            //}


            return View(CursoDAO.RetornarCursos());
        }

        public ActionResult CadastrarCurso()
        {
            ViewBag.Title = "Cadastrar Cursos";
            ViewBag.Categorias = new SelectList(
                CategoriaDAO.RetornaCategoria(), "CategoriaId", "Nome");
            ViewBag.Modalidades = new SelectList(
                ModalidadeDAO.RetornaModalidades(), "ModalidadeId", "Nome");
            ViewBag.Turnos = new SelectList(
                TurnoDAO.RetornarTurnos(), "TurnoId", "Nome");
            return View();
        }

        [HttpPost] //
        public ActionResult CadastrarCurso(Curso curso, int? categorias,
            int? modalidades, int? turnos, HttpPostedFileBase fupImagem)
        {

            ViewBag.Categorias = new SelectList(
            CategoriaDAO.RetornaCategoria(), "CategoriaId", "Nome");
            ViewBag.Modalidades = new SelectList(
                ModalidadeDAO.RetornaModalidades(), "ModalidadeId", "Nome");
            ViewBag.Turnos = new SelectList(
                TurnoDAO.RetornarTurnos(), "TurnoId", "Nome");
            if (ModelState.IsValid)
            {
                if (modalidades != null)
                {
                    if (turnos != null)
                    {
                        if (categorias != null)
                        {

                            if (fupImagem != null)
                            {
                                string nomeImagem = Path.GetFileName(fupImagem.FileName);
                                string caminho = Path.Combine(Server.MapPath("~/Imagens/"), nomeImagem);
                                fupImagem.SaveAs(caminho);
                                curso.Imagem = nomeImagem;
                            }
                            else
                            {
                                curso.Imagem = "SemImagem.jpeg";
                            }

                            curso.Categoria = CategoriaDAO.BuscarCategoriaPorId(categorias);
                            curso.Modalidade = ModalidadeDAO.BuscarModalidadePorId(modalidades);
                            curso.Turno = TurnoDAO.BuscarTurnoPorId(turnos);
                            if (CursoDAO.CadastrarCurso(curso))
                            {
                                return RedirectToAction("Index", "Curso");
                            }
                            ModelState.AddModelError("", "Esse curso ja esta cadastrado");
                        }
                        ModelState.AddModelError("", "Favor selecionar uma Categoria!");
                    }
                    ModelState.AddModelError("", "Favor selecionar um Turno");
                }
                ModelState.AddModelError("", "Favor selecionar um Modalidade");
            }
            return View(curso);
        }



        public ActionResult RemoverCurso(int id)
        {
            Curso curso = new Curso
            {
                CursoId = id
            };
            curso = CursoDAO.BuscarCursoPorId(id);
            CursoDAO.RemoverCurso(curso);

            return RedirectToAction("Index", "Curso");
        }

        public ActionResult AlterarCurso(int id)
        {
            ViewBag.Title = "Alterar Cursos";
            ViewBag.Categorias = new SelectList(
                CategoriaDAO.RetornaCategoria(), "CategoriaId", "Nome");
            ViewBag.Modalidades = new SelectList(
                ModalidadeDAO.RetornaModalidades(), "ModalidadeId", "Nome");
            ViewBag.Turnos = new SelectList(
                TurnoDAO.RetornarTurnos(), "TurnoId", "Nome");

            return View(CursoDAO.BuscarCursoPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarCurso(Curso curso, int? categorias,
            int? modalidades, int? turnos, HttpPostedFileBase fupImagem)
        {


            ViewBag.Categorias = new SelectList(
            CategoriaDAO.RetornaCategoria(), "CategoriaId", "Nome");
            ViewBag.Modalidades = new SelectList(
                ModalidadeDAO.RetornaModalidades(), "ModalidadeId", "Nome");
            ViewBag.Turnos = new SelectList(
                TurnoDAO.RetornarTurnos(), "TurnoId", "Nome");

            curso.Categoria = CategoriaDAO.BuscarCategoriaPorId(categorias);
            curso.Modalidade = ModalidadeDAO.BuscarModalidadePorId(modalidades);
            curso.Turno = TurnoDAO.BuscarTurnoPorId(turnos);
            Curso cursoaux = CursoDAO.BuscarCursoPorId(curso.CursoId);
            if (ModelState.IsValid)
            {
                if (categorias != null)
                {
                    if (modalidades != null)
                    {
                        if (turnos != null)
                        {
                            if (fupImagem != null)
                            {
                                string nomeImagem = Path.GetFileName(fupImagem.FileName);
                                string caminho = Path.Combine(Server.MapPath("~/Imagens/"), nomeImagem);
                                fupImagem.SaveAs(caminho);
                                curso.Imagem = nomeImagem;
                            }
                            else
                            {
                                curso.Imagem = "SemImagem.jpeg";
                            }

                            cursoaux.Nome = curso.Nome;
                            cursoaux.Professor = curso.Professor;
                            cursoaux.QtdVagas = curso.QtdVagas;
                            cursoaux.Valor = curso.Valor;
                            cursoaux.Duracao = curso.Duracao;
                            cursoaux.Categoria = curso.Categoria;
                            cursoaux.Modalidade = curso.Modalidade;
                            cursoaux.Turno = curso.Turno;
                            cursoaux.Imagem = curso.Imagem;
                            cursoaux.Descricao = curso.Descricao;


                            if (CursoDAO.AlterarCurso(cursoaux))
                            {
                                return RedirectToAction("Index", "Curso");

                            }
                            ModelState.AddModelError("", "Não é possivel alterrar o curso");
                        }
                        ModelState.AddModelError("", "Selecione todos os campos");
                    }
                    ModelState.AddModelError("", "Selecione todos os campos");
                }
                ModelState.AddModelError("", "Selecione todos os campos");
            }
            return View(cursoaux);
        }

        public ActionResult DetalhesCursoAdm(int? id)
        {
            ViewBag.Title = "Detalhe Curso";

            return View(CursoDAO.BuscarCursoPorId(id));
        }


    }
}