using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApplication.DAL
{
    public class ModalidadeDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarModalidade(Modalidade modalidade)
        {
            if (BuscarModalidadePorNome(modalidade) == null)
            {
                ctx.Modalidades.Add(modalidade);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        public static List<Modalidade> RetornaModalidades()
        {
            return ctx.Modalidades.ToList();
        }

        public static Modalidade BuscarModalidadePorId(int? id)
        {
            return ctx.Modalidades.Find(id);
        }

        public static Modalidade BuscarModalidadePorNome(Modalidade modalidade)
        {
            //FirstOrDefault busca apenas um objeto 
            //com base na expressão LAMBDA
            return ctx.Modalidades.FirstOrDefault(x => x.Nome.Equals(modalidade.Nome));
        }


        public static void RemoverModalidade(Modalidade modalidade)
        {
            ctx.Modalidades.Remove(modalidade);
            ctx.SaveChanges();
        }
        public static void AlterarModalidade(Modalidade modalidade)
        {
            ctx.Entry(modalidade).State = EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}