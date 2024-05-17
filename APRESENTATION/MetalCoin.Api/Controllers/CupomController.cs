using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Enums;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> ObterCuponsAtivos()
        {
            var cupom = await _cupomRepository.BuscarPorAtivos(StatusCupom.Ativo);
            if (cupom == null) BadRequest("Nenhum cupom ativo encontrado");
            return Ok(cupom);
        }

        [HttpGet]
        [Route("CuponsInativos")]
        public async Task<ActionResult> ObterCuponsInativos()
        {
            var cupom = await _cupomRepository.BuscarPorInativos(StatusCupom.Desativado);
            if (cupom == null) BadRequest("Nenhum cupom ativo encontrado");
            return Ok(cupom);
        }

        [HttpDelete]
        [Route("DesativarCupom/{id:guid}")]
        public async Task<ActionResult> DesativarCupom(Guid id)
        {

            var cupom = await _cupomRepository.DesativarCupom(id);

            if (cupom == null) return BadRequest("cupom não encontrado");
            cupom.StatusCupom = StatusCupom.Desativado;
            await _cupomRepository.AtualizarCupons(cupom);

            return Ok("cupom desativado com sucesso");
        }

        [HttpDelete]
        [Route("AtivarCupom/{id:guid}")]
        public async Task<ActionResult> AtivarCupom(Guid id)
        {

            var cupom = await _cupomRepository.AtivarCupom(id);

            if (cupom == null) return BadRequest("cupom não encontrado");
            cupom.StatusCupom = StatusCupom.Ativo;
            await _cupomRepository.AtualizarCupons(cupom);

            return Ok("Cupom ativado com sucesso");
        }

        [HttpPost]
        [Route("CadastrarCupom")]
        public async Task<ActionResult> CadastrarCategoria([FromBody] CupomCadastrarRequest cupom)
        {
            if (cupom == null) return BadRequest("Informe o nome do cupom");
            var response = await _cupomService.CupomCadastrar(cupom);

            if (response == null) return BadRequest("Cupom já existe");

            return Created("Cupom cadastrado", response);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> AtualizarCupom([FromBody] CupomAtualizarRequest cupom)
        {
            if (cupom == null) return BadRequest("Nenhum valor chegou na API");
            var response = await _cupomService.CupomAtualizar(cupom);

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeletarCupom/{id:guid}")]
        public async Task<ActionResult> RemoverCupom(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id não informado");
            var resultado = await _cupomService.DeletarCupom(id);

            if (!resultado) return BadRequest("O cupom que está tentando deletar não existe");

            return Ok("cupom deletado com sucesso");
        }
    }
}
