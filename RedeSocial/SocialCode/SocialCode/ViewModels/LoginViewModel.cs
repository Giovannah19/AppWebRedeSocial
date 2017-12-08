using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCode.ViewModels
{
        public class LoginViewModel
        {

            [Required(ErrorMessage = "Informe seu email")]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Informe sua senha")]
            public string Senha { get; set; }

        }

}