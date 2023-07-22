using AutoMapper;
using CarModule.Domain.Services.Interfaces;
using CarModule.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarModule.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ProprietarioController : ControllerBase
	{
		/* Implementar classe genérica para padronizar os retornos: https://www.youtube.com/watch?v=LghxA6lPfBA */

		private readonly IProprietarioService _proprietarioService;

		public ProprietarioController(IProprietarioService proprietarioService)
		{
			_proprietarioService = proprietarioService;
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> ObterProprietarioPorId(long id) 
		{
			var result = await _proprietarioService.ObterProprietarioPorId(id);

			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> ConsultarProprietarios()
		{
			var result = await _proprietarioService.ConsultarProprietarios();

			if (result == null || !result.Any())
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> SalvarProprietario(CadastroProprietarioDTO proprietarioDTO) 
		{
			var result = await _proprietarioService.SalvarProprietario(proprietarioDTO);

			if (result == null)
				return BadRequest("Erro ao cadastrar o proprietário!");

			return Ok(result);	
		}

		[HttpPut]
		public async Task<IActionResult> AtualizarProprietario(AtualizaProprietarioDTO proprietarioDTO) 
		{
			var result = await _proprietarioService.AtualizarProprietario(proprietarioDTO);

			if (result == null)
				return BadRequest("Erro ao atualizar o proprietário!");

			return Ok(result);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeletarProprietario(long id) 
		{
			var result = await _proprietarioService.DeletarProprietario(id);

			if (!result)
				return BadRequest();

			return Ok(result);
		}

		[HttpGet]
		[Route("veiculo/{placa}")]
		public async Task<IActionResult> ObterVeiculoPorPlaca(string placa) 
		{
			var result = await _proprietarioService.ObterVeiculoPorPlaca(placa);

			if (result == null)
				return BadRequest("Erro ao obter o veículo!");

			return Ok(result);
		}

		[HttpPost]
		[Route("veiculo")]
		public async Task<IActionResult> AdicionarVeiculo(CadastroVeiculoDTO veiculoDTO) 
		{
			var result = await _proprietarioService.SalvarVeiculo(veiculoDTO);

			if (result == null)
				return BadRequest("Erro ao salvar o veículo!");

			return Ok(result);
		}

		[HttpPut]
		[Route("veiculo")]
		public async Task<IActionResult> AtualizarVeiculo(CadastroVeiculoDTO veiculoDTO)
		{
			var result = await _proprietarioService.AtualizarVeiculo(veiculoDTO);

			if (result == null)
				return BadRequest("Erro ao atualizar o veículo!");

			return Ok(result);
		}

		[HttpDelete]
		[Route("{id}/veiculo/{placa}")]
		public async Task<IActionResult> DeletarVeiculo(long id, string placa) 
		{
			var result = await _proprietarioService.DeletarVeiculo(id, placa);

			if (!result)
				return BadRequest("Erro ao excluir o veículo");

			return Ok(result);
		}
	}
}
