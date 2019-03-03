using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApplication.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo Estado Obrigatorio")]
        public string Estado { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Campo Cidade  Obrigatorio")]
        [MaxLength(50, ErrorMessage = "No maximo 50 caracteres!")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Campo Bairro Obrigatorio")]
        [MaxLength(50, ErrorMessage = "No maximo 50 caracteres!")]
        public string Bairro { get; set; }

        [Display(Name = "Lograduro")]
        [Required(ErrorMessage = "Campo Loradouro Obrigatorio")]
        [MaxLength(50, ErrorMessage = "No maximo 50 caracteres!")]
        public string Rua { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Campo Numero Obrigatorio")]
        public int Numero { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(50, ErrorMessage = "No maximo 50 caracteres!")]
        public string Complemento { get; set; }

    }


}