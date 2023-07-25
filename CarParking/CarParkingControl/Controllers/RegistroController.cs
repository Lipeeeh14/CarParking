using CarParkingControl.Domain.Services.Interfaces;
using CarParkingControl.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarParkingControl.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class RegistroController : ControllerBase
	{
		private readonly IRegistroService _registroService;

		public RegistroController(IRegistroService registroService)
		{
			_registroService = registroService;
		}

		[HttpPost]
		[Route("entrada")]
		public async Task<IActionResult> RegistrarEntrada(RegistroEntradaDTO registroEntradaDTO) 
		{
			var result = await _registroService.RegistrarEntrada(registroEntradaDTO);

			if (result == null) 
				return BadRequest("Erro ao registrar entrada do veículo!");

			return Ok(result);
		}

		[HttpPost]
		[Route("saida")]
		public async Task<IActionResult> RegistrarSaida(RegistroSaidaDTO registroSaidaDTO)
		{
			var result = await _registroService.RegistrarSaida(registroSaidaDTO);

			if (result == null)
				return BadRequest("Erro ao registrar saída do veículo!");

			return Ok(result);
		}
	}
}
