using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;

namespace Metalcoin.Core.Interfaces.Services
{
    public interface ICupomService
    {
        Task<CupomResponse> CupomCadastrar(CupomCadastrarRequest cupom);
        Task<CupomResponse> CupomAtualizar(CupomAtualizarRequest cupom);
        Task<bool> DeletarCupom(Guid id);
    }
}
