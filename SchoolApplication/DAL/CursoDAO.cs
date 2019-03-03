using SchoolApplication.Models;
using SchoolApplication.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApplication.DAL
{
    public class CursoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static bool CadastrarCurso(Curso curso)
        {
            if (BuscarCursoPorNome(curso) == null)
            {
                ctx.Cursos.Add(curso);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Curso> RetornarCursos()
        {
            //Retornar todos os objetos da tabela
            return ctx.Cursos.
                Include("Categoria").
                Include("Turno").
                Include("Modalidade").ToList();
        }

        public static Curso BuscarCursoPorNome(Curso curso)
        {
            //FirstOrDefault busca apenas um objeto 
            //com base na expressão LAMBDA
            return ctx.Cursos.FirstOrDefault(x => x.Nome.Equals(curso.Nome));
        }

        public static bool AlterarCurso(Curso curso)
        {
            if (BuscarCursoPorId(curso.CursoId) != null)
            {
                ctx.Entry(curso).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;

        }

        public static void RemoverCurso(Curso curso)
        {
            ctx.Cursos.Remove(curso);
            ctx.SaveChanges();
        }
        public static Curso BuscarCursoPorId(int? id)
        {
            //Find busca apenas um objeto 
            //no campo da chave primária
            return ctx.Cursos.Find(id);
        }

        public static List<Curso> BuscarCursoPorCategoria(int? id)
        {
            return ctx.Cursos.Where(x => x.Categoria.CategoriaId == id).ToList();
        }

        public static List<Curso> BuscarCursoPorTurno(int? id)
        {
            return ctx.Cursos.Where(x => x.Turno.TurnoId == id).ToList();
        }

        public static List<Curso> BuscarCursoPorModalidade(int? id)
        {
            return ctx.Cursos.Where(x => x.Modalidade.ModalidadeId == id).ToList();
        }

        //public static Curso RetornarCursoPorCarrinhoId()
        //{
        //    string carrinhoId = Sessao.RetornarInscricaoId();
        //    return ctx.Cursos.
        //        Include("Categoria").
        //        Include("Turno").
        //        Include("Modalidade").

        //        FirstOrDefault(x => x.InscricaoId.Equals(carrinhoId));
        //}



    }
}