using CarParking.Domain.Services.Interfaces;
using CarParking.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarParking.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class SetorController : ControllerBase
	{
		/* Implementar classe genérica para padronizar os retornos: https://www.youtube.com/watch?v=LghxA6lPfBA */

		private readonly ISetorService _setorService;

		public SetorController(ISetorService setorService)
		{
			_setorService = setorService;
		}

		[HttpGet]
		public async Task<IActionResult> ObterSetores()
		{
			var result = await _setorService.ObterSetores();

			if (result == null || !result.Any())
				return NotFound();

			return Ok(result);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> ObterSetorPorId(long id) 
		{
			var result = await _setorService.ObterSetorPorId(id);

			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CadastrarSetor(CadastroSetorDTO setorDTO) 
		{
			var result = await _setorService.SalvarSetor(setorDTO);

			if (result == null)
				return BadRequest("Erro ao cadastrar o setor!");

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> AtualizarSetor(AtualizaSetorDTO setorDTO) 
		{
			var result = await _setorService.AtualizarSetor(setorDTO);

			if (result == null)
				return BadRequest("Erro ao atualizar o setor!");

			return Ok(result);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeletarSetor(long id) 
		{
			var result = await _setorService.DeletarSetor(id);

			if (!result)
				return BadRequest();

			return Ok();
		}

		[HttpPost]
		[Route("vaga")]
		public async Task<IActionResult> CadastrarVaga(CadastroVagaDTO vagaDTO) 
		{
			var result = await _setorService.CadastrarVaga(vagaDTO);

			if (result == null)
				return BadRequest("Erro ao cadastrar a vaga!");

			return Ok(result);
		}

		[HttpDelete]
		[Route("{id}/vaga/{numero}")]
		public async Task<IActionResult> DeletarVaga(long id, int numero) 
		{
			var result = await _setorService.DeletarVaga(id, numero);

			if (!result)
				return BadRequest();

			return Ok();
		}

		[HttpPatch]
		[Route("vaga/status")]
		public async Task<IActionResult> AtualizarStatusVaga(VagaOcupadaDTO vagaOcupadaDTO) 
		{
			var result = await _setorService.AtualizarStatusVaga(vagaOcupadaDTO);

			if (!result)
				return BadRequest();

			return Ok();
		}
	}
}
