using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApplication.DAL
{
    public class TurnoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarTurno(Turno turno)
        {
            if (BuscarTurnoPorNome(turno) == null)
            {
                ctx.Turnos.Add(turno);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Turno> RetornarTurnos()
        {
            return ctx.Turnos.ToList();
        }

        public static Turno BuscarTurnoPorId(int? id)
        {
            return ctx.Turnos.Find(id);
        }

        public static Turno BuscarTurnoPorNome(Turno turno)
        {
            //FirstOrDefault busca apenas um objeto 
            //com base na expressão LAMBDA
            return ctx.Turnos.FirstOrDefault(x => x.Nome.Equals(turno.Nome));
        }

        public static void RemoverTurno(Turno turno)
        {
            ctx.Turnos.Remove(turno);
            ctx.SaveChanges();
        }
        public static void AlterarTurno(Turno turno)
        {
            ctx.Entry(turno).State = EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}