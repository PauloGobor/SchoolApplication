using SchoolApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApplication.Controllers
{
    public class MatriculaController : Controller
    {
        // GET: Matriula
        public ActionResult Index(int? id)
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Title = "Gerenciamento de Matriculas";
            
            ViewBag.Cursos = CursoDAO.RetornarCursos();

            if (id == null || id == 0)
            {

                return View(MatriculaDAO.RetornarMatriculas());

            }
            
            return View(MatriculaDAO.BuscarMatriculaPorCurso(id));
            
        }

        
    }
}