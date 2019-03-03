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
    [RoutePrefix("api/Curso")]//api/matriculasporcurso criaar
    public class CursoApiController : ApiController
    {
        //GET: api/Cursos/Cursos
        [Route("Cursos")]
        public List<Curso> GetCursos()
        {
            return CursoDAO.RetornarCursos();
        }

        //GET: api/Curso/CursosPorCategoria/3
        [Route("CursosPorCategoria/{categoriaId}")]
        public List<Curso> GetCursosPorCategoria (int categoriaId)
        {
            return CursoDAO.BuscarCursoPorCategoria(categoriaId);
        }

        //GET: api/Cursos/cursoporId/3
        [Route("CursoPorId/{cursoId}")]
        public dynamic GetCursoPorId(int cursoId)
        {
            Curso curso = CursoDAO.BuscarCursoPorId(cursoId);
            if(curso != null)
            {
                dynamic dinamic = new
                {
                 nome = curso.Nome,
                 duracao = curso.Duracao,
                 valor = curso.Valor,
                 Vagas = curso.QtdVagas,
                 modalidade = curso.Modalidade.Nome,
                 turno = curso.Turno.Nome,
                 categoria = curso.Categoria.Nome
                    
                };
                return dinamic;
            }
            return NotFound();
        }
    }
}

//http codename Google
