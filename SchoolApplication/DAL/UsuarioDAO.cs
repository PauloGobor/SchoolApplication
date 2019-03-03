using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApplication.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static bool CadastrarUsuario(Usuario usuario)
        {
            if (BuscarUsuarioPorCpf(usuario.Cpf) == null)
            {
                if (BuscarUsarioPorEmail(usuario.Email) == null)
                {
                    ctx.Usuarios.Add(usuario);
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public static List<Usuario> RetornarUsuarios()
        {
            //Retornar todos os objetos da tabela
            return ctx.Usuarios.
                Include("Role").
                ToList();
        }
        public static Usuario BuscarusuarioPorNome(Usuario usuario)
        {
            //FirstOrDefault busca apenas um objeto 
            //com base na expressão LAMBDA
            return ctx.Usuarios.FirstOrDefault(x => x.Nome.Equals(usuario.Nome));
        }

        public static Usuario BuscarUsarioPorEmail(string email)
        {
            //FirstOrDefault busca apenas um objeto 
            //com base na expressão LAMBDA
            return ctx.Usuarios.FirstOrDefault(x => x.Email.Equals(email));
        }

        public static Usuario BuscarUsuarioPorId(Usuario usuario)
        {
            //Find busca apenas um objeto 
            //no campo da chave primária
            return ctx.Usuarios.Find(usuario.UsuarioId);
        }
        public static List<Usuario> BuscarUsuarioPorParteDoNome(Usuario usuario)
        {
            //Where busca apenas vários objetos 
            //com base na expressão LAMBDA
            return ctx.Usuarios.
                Where(x => x.Nome.Contains(usuario.Nome)).ToList();
        }

        public static Usuario RelizarLongin(Usuario usuario)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email.Equals(usuario.Email) &&
            x.Senha.Equals(usuario.Senha));
        }
        public static Usuario BuscarUsuarioPorCpf(string cpf)
        {
            //Find busca apenas um objeto 
            //no campo da chave primária
            return ctx.Usuarios.FirstOrDefault(x => x.Cpf.Equals(cpf));
        }



            //public static Aluno BuscaSenhaAluno(Aluno aluno)
            //{
            //    return ctx.Alunos.FirstOrDefault(x => x.Senha.Equals(aluno.Senha));
            //}
        }
}