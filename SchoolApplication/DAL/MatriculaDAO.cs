using SchoolApplication.Models;
using SchoolApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApplication.DAL
{
    public class MatriculaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool RealizarMatricula(Matricula matricula)
        {
            if (BuscarMatriculaPorAlunoTurno(matricula) != null)
            {
                return false;
            }

            ctx.Matriculas.Add(matricula);
            ctx.SaveChanges();
            return true;

        }

        public static List<Matricula> RetornarMatriculas()
        {
            //Retornar todos os objetos da tabela
            return ctx.Matriculas.
                Include("Usuario").
                Include("Curso").
                ToList();
        }



        public static List<Matricula> BuscarMatriculaPorCurso(int? id)
        {
            return ctx.Matriculas.
                Include("Usuario").
                Include("Curso").
                Where(x => x.Curso.CursoId == id).ToList();
        }


        public static Matricula BuscarMatriculaPorAlunoTurno(Matricula matricula)
        {
            return ctx.Matriculas.
                Include("Usuario").
                Include("Curso.Turno").
                FirstOrDefault(x => x.Usuario.UsuarioId.Equals(matricula.Usuario.UsuarioId) &&
                x.Curso.Turno.Nome.Equals(matricula.Curso.Turno.Nome));
        }

        public static List<Matricula> RetornarCursosPorAluno(int? id)
        {
            return ctx.Matriculas.
                Include("Usuario").
                Include("Curso").
                Where(x => x.Usuario.UsuarioId == id).ToList();
        }



        //trazer os cursos do aluno //Meus cursos
        // em meus cursos levar o id da matricula do aluno logado

        //public static List<Matricula> BuscaCursoPorAluno(int? id)//id do aluno
        //{
        //    return ctx.Matriculas.
        //        Include("Usuario").
        //        Include("Curso").
        //        Where(x => x.IdMatricula == id).ToList();
        //}
        /// trazer o perfil de quem esta cadastrado comparar quaando entrar em uma pagina

    }


}



