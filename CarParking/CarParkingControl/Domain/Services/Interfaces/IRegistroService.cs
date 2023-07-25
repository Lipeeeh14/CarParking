using CarParkingControl.DTOs;
using CarParkingControl.ViewModels;

namespace CarParkingControl.Domain.Services.Interfaces
{
	public interface IRegistroService
	{
		Task<RegistroVagaViewModel?> RegistrarEntrada(RegistroEntradaDTO registroVagaDTO);
		Task<RegistroVagaViewModel?> RegistrarSaida(RegistroSaidaDTO registroSaidaDTO);
	}
}
