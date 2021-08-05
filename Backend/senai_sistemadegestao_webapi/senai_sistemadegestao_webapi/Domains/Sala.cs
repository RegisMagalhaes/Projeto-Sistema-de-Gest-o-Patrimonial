using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_sistemadegestao_webapi.Domains
{
    public partial class Sala
    {
        public Sala()
        {
            Equipamentos = new HashSet<Equipamento>();
        }

        public int IdSala { get; set; }
        [Required(ErrorMessage = "O cadastro do Andar da sala é obrigatório!")]
        public string Andar { get; set; }
        [Required(ErrorMessage = "O cadastro do nome da Sala é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O cadastro da metragem da Sala é obrigatório!")]
        public string Metragem { get; set; }

        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
