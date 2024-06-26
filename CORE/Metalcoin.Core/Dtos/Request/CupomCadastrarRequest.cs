﻿using Metalcoin.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Metalcoin.Core.Dtos.Request
{
    public record CupomCadastrarRequest
    {
        [Required(ErrorMessage = "Codigo do Cupom é obrigatorio ")]
        public string CodigoCupom { get; set; }


        [MaxLength(100, ErrorMessage = "Descrição pode ter no máximo 100 caracteres")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Valor do Desconto é obrigatorio ")]
        public decimal ValorDesconto { get; set; }


        [Required(ErrorMessage = "Tipo de Desconto é obrigatorio ")]
        public TipoDesconto TipoDesconto { get; set; }


        [Required(ErrorMessage = "Data de Validade é obrigatorio ")]
        [DataType(DataType.DateTime)]
        public DateTime DataValidade { get; set; }


        [Required(ErrorMessage = "Quantidade de Cupons Liberados é obrigatorio ")]
        public int QtdCuponsLiberados { get; set; }


        [Required(ErrorMessage = "Status do Cupom é obrigatorio ")]
        public StatusCupom StatusCupom { get; set; }
        
    }
}
