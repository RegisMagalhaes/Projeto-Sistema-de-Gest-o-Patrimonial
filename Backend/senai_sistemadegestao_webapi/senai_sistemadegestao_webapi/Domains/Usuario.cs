using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_sistemadegestao_webapi.Domains
{
    public partial class Usuario
    {
        [Required(ErrorMessage = "E-mail obrigatório!")]
        [StringLength(50, MinimumLength =5, ErrorMessage ="A senha deverá ter de 5 a 50 caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite sua senha novamente!")]
        public string Senha { get; set; }
        public int IdUsuario { get; set; }
    }
}
