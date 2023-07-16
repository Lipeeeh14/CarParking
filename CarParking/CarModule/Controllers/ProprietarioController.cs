using AutoMapper;
using CarModule.Domain.Services.Interfaces;
using CarModule.DTOs;
using CarModule.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarModule.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ProprietarioController : ControllerBase
	{
		/* Implementar classe genérica para padronizar os retornos: https://www.youtube.com/watch?v=LghxA6lPfBA */

		private readonly IProprietarioService _proprietarioService;

		public ProprietarioController(IProprietarioService proprietarioService, IMapper mapper)
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
	}
}
