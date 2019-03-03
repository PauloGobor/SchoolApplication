using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApplication.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        //stringmaxlengt
        //CPF
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Cpf { get; set; }

        //Perfil Usuario
        public Role Role { get; set; }

        //Nome
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Nome Obrigatório")]
        [MaxLength(50, ErrorMessage = "No maximo 50 caracteres!")]
        public string Nome { get; set; }

        //Telefone
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo Telefone Obrigatório")]
        [MaxLength(20, ErrorMessage = "No maximo 12 caracteres!")]
        public string Telefone { get; set; }
        //Sexo
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Sexo { get; set; }

        //Data Nascimento
        [Display(Name = "Data Nascimento")]
        [Required(ErrorMessage = "Campo Data Nascimento Obrigatório")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataNasc { get; set; }

        //email
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Email Obrigatório")]
        [EmailAddress(ErrorMessage ="Email Invalido")]
        public string Email { get; set; }
        //Senha
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha deve ser preenchida!")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Senha deve ter entre 4 e 15 caracteres")]
        public string Senha { get; set; }

        //comfirma senha
        [NotMapped]// nao cria a tabela no banco
        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessage = "Senhas informadas não conferem")]
        public string ConfirmaSenha { get; set; }

        public Endereco Endereco { get; set; }
    }
}