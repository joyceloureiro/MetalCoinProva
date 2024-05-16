using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;

namespace MetalCoin.Application.Services
{
    public class CupomService : ICupomService
    {
        private readonly ICupomRepository _cupomRepository;
        public CupomService(ICupomRepository repository)
        {
            _cupomRepository = repository;
        }
        public async Task<CupomResponse> CupomAtualizar(CupomAtualizarRequest cupom)
        {
            var cupomDb = await _cupomRepository.ObterPorId(cupom.Id);

            cupomDb.Descricao = cupom.Descricao;
            cupomDb.CodigoCupom = cupom.CodigoCupom.ToUpper();
            cupomDb.ValorDesconto = cupom.ValorDesconto;
            cupomDb.TipoDesconto = cupom.TipoDesconto;
            cupomDb.DataValidade = cupom.DataValidade;
            cupomDb.QtdCuponsLiberados = cupom.QtdCuponsLiberados;
            cupomDb.StatusCupom = cupom.Status;

            await _cupomRepository.Atualizar(cupomDb);

            var response = new CupomResponse
            {
                Id = cupomDb.Id,
                CodigoCupom = cupomDb.CodigoCupom,
                Descricao = cupomDb.Descricao,
                ValorDesconto = cupomDb.ValorDesconto,
                QtdCuponsLiberados = cupomDb.QtdCuponsLiberados,
                QtdCuponsUsados = cupomDb.QtdCuponsUsados,
                TipoDesconto = cupomDb.TipoDesconto,
                StatusCupom = cupomDb.StatusCupom,
                DataValidade = cupomDb.DataValidade
            };

            return response;
        }

        public async Task<CupomResponse> CupomCadastrar(CupomCadastrarRequest cupom)
        {

            var cupomEntidade = new Cupom
            {
               
                CodigoCupom = cupom.CodigoCupom,
                Descricao = cupom.Descricao,
                ValorDesconto = cupom.ValorDesconto,
                QtdCuponsLiberados = cupom.QtdCuponsLiberados,
                TipoDesconto = cupom.TipoDesconto,
                StatusCupom = cupom.StatusCupom,
                DataValidade = cupom.DataValidade
            };

            await _cupomRepository.Adicionar(cupomEntidade);

            var response = new CupomResponse
            {
                Id = cupomEntidade.Id,
                CodigoCupom = cupomEntidade.CodigoCupom,
                Descricao = cupomEntidade.Descricao,
                ValorDesconto = cupomEntidade.ValorDesconto,
                QtdCuponsLiberados = cupomEntidade.QtdCuponsLiberados,
                QtdCuponsUsados = cupomEntidade.QtdCuponsUsados,
                TipoDesconto = cupomEntidade.TipoDesconto,
                StatusCupom = cupomEntidade.StatusCupom,
                DataValidade = cupomEntidade.DataValidade
            };

            return response;
        }

        public async Task<bool> DeletarCupom(Guid id)
        {
            var cupom = await _cupomRepository.ObterPorId(id);
            if (cupom == null) return false;


            await _cupomRepository.RemoverCupom(id);
            return true;
        }
    }

    
}
