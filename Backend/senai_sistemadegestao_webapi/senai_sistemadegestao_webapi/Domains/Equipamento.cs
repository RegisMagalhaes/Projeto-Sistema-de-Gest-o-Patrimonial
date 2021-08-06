using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_sistemadegestao_webapi.Domains
{
    public partial class Equipamento
    {
        public int IdEquipamento { get; set; }
        public int? IdSala { get; set; }

        [Required(ErrorMessage = "O cadastro da Marca do Equipamento é obrigatório!")]
        
        public string Marca { get; set; }
        [Required(ErrorMessage = "O cadastro do tipo do Equipamento é obrigatório!")]
       
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O cadastro do número de Série do Equipamento é obrigatório!")]
        
        public string NumeroDeSerie { get; set; }
        [Required(ErrorMessage = "O cadastro da Descrição do Equipamento é obrigatório!")]
       
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Ativo ou Inativo?")]
        
        public string Status { get; set; }

        public string NumeroPatrimonio { get; set; }
        [Required(ErrorMessage = "O número do patrimônio é obrigatório")]

        public virtual Sala IdSalaNavigation { get; set; }
    }
}
