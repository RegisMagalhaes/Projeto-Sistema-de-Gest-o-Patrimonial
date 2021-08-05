using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_sistemadegestao_webapi.Domains
{
    public partial class Usuario
    {
        [Required(ErrorMessage = "E-mail obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite sua senha novamente!")]
        public string Senha { get; set; }
    }
}
