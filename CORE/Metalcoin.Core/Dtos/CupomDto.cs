using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos
{
    public class CupomDto
    {
        public Guid Id { get; set; }
        public string CodigoCupom { get; set; }
        public string Descricao { get; set; }
        public decimal ValorDesconto { get; set; }
        public int QtdCuponsLiberados { get; set; }
        public int QtdCuponsUsados { get; set; }
        public TipoDesconto TipoDesconto { get; set; }
        public StatusCupom StatusCupom { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
