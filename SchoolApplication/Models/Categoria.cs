using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApplication.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        //Nome
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(30, ErrorMessage = "No maximo 30 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}