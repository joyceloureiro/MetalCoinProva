using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos.Request
{
    public class CupomCadastrarRequest
    {
        [Required(ErrorMessage = "Codigo do Cupom é obrigatorio é obrigátorio")]
        public string CodigoCupom { get; set; }


        [MaxLength(100, ErrorMessage = "Descrição pode ter no máximo 100 caracteres")]
        public string Descricao { get; set; }

        public decimal ValorDesconto { get; set; }
        public TipoDesconto TipoDesconto { get; set; }
      
        public int QtdCuponsLiberados { get; set; }
     
        public StatusCupom Status { get; set; }
        
    }
}
