using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Interfaces.Repositories
{
    public interface ICupomRepository : IRepository<Cupom>
    {
        Task<Cupom> BuscarPorAtivos(StatusCupom statusCupom);
        Task<Cupom> BuscarPorInativos(StatusCupom statusCupom);
        Task<Cupom> DesativarCupom(Guid id);
    }
}
