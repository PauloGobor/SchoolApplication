using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApplication.Models
{


    [Table("Matricula")]
    public class Matricula
    {
        public Matricula()
        {
            Usuario = new Usuario();
            Curso = new Curso();
        }

        [Key]
        public int IdMatricula { get; set; }
        public Usuario Usuario { get; set; }
        public Curso Curso { get; set; }



    }

}














//public string InscricaoId { get; set; }
