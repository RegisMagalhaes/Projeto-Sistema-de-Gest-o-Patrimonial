using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.ViewModels
{
    /// <summary>
    /// Responsável pelo modelo do Login
    /// </summary>
    public class LoginViewModel
    {   //Define que o email é obrigatório
        [Required(ErrorMessage = "Informe o email do usuário!")]
        public string Email { get; set; }
        //Define que a senha é obrigatória
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }
    }
}
