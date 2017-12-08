using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCode.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Informe seu nome completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu email")]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua data de nascimento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime dtnascimento { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        [Required(ErrorMessage = "Informe sua senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não correspondem")]
        [Required(ErrorMessage = "Confirme sua senha")]
        public string ConfirmaSenha { get; set; }

        public int Sexo { get; set; }
        public String Interesses { get; set; }
    }

}