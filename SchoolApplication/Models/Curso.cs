using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApplication.Models
{
    /// <summary>
    /// Annotations c#
    /// </summary>
    /// 
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        //Nome
        [Display(Name ="Nome")]
        [Required(ErrorMessage ="Campo Nome Obrigatório")]
        [MaxLength(40,ErrorMessage ="No maximo 40 caracteres!")]
        public string Nome { get; set; }
        //professor
        [Display(Name = "Professor")]
        [Required(ErrorMessage = "Campo Professor Obrigatório")]
        public string Professor { get; set; }
        //Vagas
        [Display(Name = "Vagas")]
        [Required(ErrorMessage = "Campo Vagas Obrigatório")]
        public int QtdVagas { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo Valor Obrigatório")]
        //range =valor maximo
        public double Valor { get; set; }

        // meses
        [Display(Name ="Tempo em Meses")]
        [Required(ErrorMessage ="Campo Duração Obrigatório")]
        public int Duracao { get; set; }

        //modalidade
        [Display(Name = "Modalidade")]
        public Modalidade Modalidade { get; set; }
        //categoria
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        //turno
        [Display(Name = "Turno")]
        public Turno Turno { get; set; }
        //imagem
        public string Imagem { get; set; }
        //descricao
        [Display(Name = "Descrição")]
        [MaxLength(2000, ErrorMessage = "No maximo 2000 caracteres!")]
        public string Descricao{ get; set; }




    }
}