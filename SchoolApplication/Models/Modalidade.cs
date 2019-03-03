using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApplication.Models
{
    [Table("Modalidade")]
    public class Modalidade
    {

        [Key]
        public int ModalidadeId { get; set; }
        //Modalidade
        [Display(Name = "Modalidade")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MaxLength(20, ErrorMessage = "No maximo 20 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}