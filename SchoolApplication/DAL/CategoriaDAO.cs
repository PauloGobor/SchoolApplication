using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApplication.DAL
{
    public class CategoriaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarCategoria(Categoria categoria)
        {
            if (BuscarCategoriaPorNome(categoria) == null)
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
                return true;
            }
            return false;

        }
        public static List<Categoria> RetornaCategoria()
        {
            return ctx.Categorias.ToList();
        }

        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return ctx.Categorias.Find(id);
        }

        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            //FirstOrDefault busca apenas um objeto 
            //com base na expressão LAMBDA
            return ctx.Categorias.FirstOrDefault(x => x.Nome.Equals(categoria.Nome));
        }

        //public static DiaSemana BuscarDiaDaSemanaPorNome(DiaSemana dia)
        //{
        //    //FirstOrDefault busca apenas um objeto 
        //    //com base na expressão LAMBDA
        //    return ctx.DiasdaSemana.FirstOrDefault(x => x.Nome.Equals(dia.Nome));
        //}

        public static void RemoverCategoria(Categoria categoria)
        {
            ctx.Categorias.Remove(categoria);
            ctx.SaveChanges();
        }
        public static void AlterarCategoria(Categoria categoria)
        {
            ctx.Entry(categoria).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}