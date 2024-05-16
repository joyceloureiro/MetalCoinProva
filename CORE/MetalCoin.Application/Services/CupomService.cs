using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var cupomExistente = await _cupomRepository.BuscarPorNome(cupom.Nome);

            if (cupomExistente != null) return null;

            var categoriaEntidade = new Categoria
            {
                Nome = categoria.Nome.ToUpper(),
                Status = categoria.Status,
                DataCadastro = DateTime.Now,
                DataAlteracao = DateTime.Now
            };

            await _cupomRepository.Adicionar(cupomEntidade);

            var response = new CategoriaResponse
            {
                Id = categoriaEntidade.Id,
                Nome = categoriaEntidade.Nome,
                Status = categoriaEntidade.Status,
                DataCadastro = categoriaEntidade.DataCadastro,
                DataAlteracao = categoriaEntidade.DataAlteracao
            };

            return response;
        }

    }

    public async Task<bool> DeletarCupom(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
