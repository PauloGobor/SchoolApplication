using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApplication.Models
{
    [Table("Turnos")]
    public class Turno
    {
        [Key]
        public int TurnoId { get; set; }
        //Turno
        [Display(Name = "Turno")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MaxLength(20, ErrorMessage = "No maximo 20 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}