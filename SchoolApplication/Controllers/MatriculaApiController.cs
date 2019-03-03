using SchoolApplication.DAL;
using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolApplication.Controllers
{
    [RoutePrefix("api/Matricula")]
    public class MatriculaApiController : ApiController
    {

        [Route("Matriculas")]
        public List<Matricula> GetMatriculas()
        {
            return MatriculaDAO.RetornarMatriculas();
        }

        [Route("MatriculasPorCurso/{cursoId}")]
        public List<Matricula> GetMatriculasPorCurso(int cursoId)
        {
          

            return MatriculaDAO.BuscarMatriculaPorCurso(cursoId);
        }


        //[Route("MatriculasPorCurso/{cursoId}")]
        //public List<dynamic> GetMatriculasPorCurso(int cursoId)
        //{
        //    List<Matricula> matriculas = MatriculaDAO.BuscarMatriculaPorCurso(cursoId);

        //    if (matriculas != null)
        //    {
        //        foreach (var item in matriculas)
        //        {
        //            dynamic dinamic = new
        //            {
        //                Aluno = item.Usuario.Nome


        //            };
        //            return dinamic;

        //        }
        //    }
        //    return NotFound();
        //}





    }
}
