using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using MetalCoin.Infra.Data.Repositories;
using MetalCoin.Application.Services;
using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;

namespace MetalCoin.Api.Controllers
{
    [ApiController]
    public class CupomController : ControllerBase
    {
        private readonly ICupomRepository _cupomRepository;
        private readonly ICupomService _cupomService;

        public CupomController(ICupomRepository cupomRepository, ICupomService cupomService)
        {
            _cupomRepository = cupomRepository;
            _cupomService = cupomService;
        }

        [HttpGet]
        [Route("todosCupons")]
        public async Task<ActionResult> ObterTodosCupons()
        {
            var listaCupons = await _cupomRepository.ObterTodosCupons();

            if (listaCupons.Count == 0) return NoContent();

            return Ok(listaCupons);
        }

        [HttpGet]
        [Route("CuponsAtivos")]
        public async Task<ActionResult> ObterCuponsAtivos(StatusCupom statusCupom)
        {
            var categoria = await _cupomRepository.BuscarPorAtivos(statusCupom);
            if (categoria == null) return BadRequest("Categoria não encontrada");
            return Ok(categoria);
        }

        [HttpPost]
        [Route("cadastrar Cupom")]
        public async Task<ActionResult> CadastrarCategoria([FromBody] CupomCadastrarRequest cupom)
        {
            if (cupom == null) return BadRequest("Informe o nome do cupom");

            var response = await _cupomService.CupomCadastrar(cupom);

            if (response == null) return BadRequest("Cupom já existe");

            return Created("cupom", response);
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult> AtualizarCupom([FromBody] CupomAtualizarRequest cupom)
        {
            if (cupom == null) return BadRequest("Nenhum valor chegou na API");

            var response = await _cupomService.CupomAtualizar(cupom);

            return Ok(response);
        }

        [HttpDelete]
        [Route("deletarCupom/{id:guid}")]
        public async Task<ActionResult> RemoverCupom(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id não informado");

            var resultado = await _cupomService.DeletarCupom(id);

            if (!resultado) return BadRequest("O cupom que está tentando deletar não existe");

            return Ok("cupom deletado com sucesso");
        }
    }
}
