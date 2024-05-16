using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos.Request
{
    public record CupomAtualizarRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Codigo do Cupom é obrigatorio ")]
        public string CodigoCupom { get; set; }


        [MaxLength(100, ErrorMessage = "Descrição pode ter no máximo 100 caracteres")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Valor do Desconto é obrigatorio ")]
        public decimal ValorDesconto { get; set; }


        [Required(ErrorMessage = "Tipo de Desconto é obrigatorio ")]
        public TipoDesconto TipoDesconto { get; set; }


        [Required(ErrorMessage = "Data de Validade é obrigatorio ")]
        public DateTime DataValidade { get; set; }


        [Required(ErrorMessage = "Quantidade de Cupons Liberados é obrigatorio ")]
        public int QtdCuponsLiberados { get; set; }


        [Required(ErrorMessage = "Status do Cupom é obrigatorio ")]
        public StatusCupom Status { get; set; }
    }
}
