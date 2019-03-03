using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApplication.Models
{
    public class Context : DbContext
    {
        public Context() : base("School") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Curso> Cursos { get; set; }


        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


       // public DbSet<ItemMatricula> ItemMatricula { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }


    }

}