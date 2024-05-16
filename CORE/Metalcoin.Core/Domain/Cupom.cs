using Metalcoin.Core.Abstracts;
using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Domain
{
    public class Cupom : Entidade
    {
        public string CodigoCupom { get; set; }
        public string Descricao { get; set; }
        public decimal ValorDesconto { get; set; }
        public int QtdCuponsLiberados { get; set; }
        public int QtdCuponsUsados { get; set; }
        public TipoDesconto TipoDesconto { get; set; }
        public StatusCupom Status { get; set; }
        public DateTime DataValidade { get; set; }

    }
}
