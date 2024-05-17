using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;

namespace Metalcoin.Core.Interfaces.Repositories
{
    public interface ICupomRepository : IRepository<Cupom>
    {
        Task<Cupom> BuscarPorAtivos(StatusCupom statusCupom);
        Task<Cupom> BuscarPorInativos(StatusCupom statusCupom);
        Task<Cupom> DesativarCupom(Guid id);
        Task<Cupom> AtivarCupom(Guid id);
    }
}
