using AutoMapper;
using CarParkingControl.Data.Repositories.Interfaces;
using CarParkingControl.Domain.Models;
using CarParkingControl.Domain.Services.Interfaces;
using CarParkingControl.DTOs;
using CarParkingControl.Integration.Interfaces;
using CarParkingControl.ViewModels;

namespace CarParkingControl.Domain.Services
{
	public class RegistroService : IRegistroService
	{
		private IMapper _mapper;

		private readonly IRegistroRepository _registroRepository;

		private readonly ICarParkingHttpClient _carParkingHttpClient;

		public RegistroService(IMapper mapper, IRegistroRepository registroRepository, ICarParkingHttpClient carParkingHttpClient)
		{
			_mapper = mapper;
			_registroRepository = registroRepository;
			_carParkingHttpClient = carParkingHttpClient;
		}

		public async Task<RegistroVagaViewModel?> RegistrarEntrada(RegistroEntradaDTO registroVagaDTO)
		{
			var registros = await _registroRepository.ObterRegistrosPorVagaIdOuPlaca(registroVagaDTO.PlacaVeiculo, registroVagaDTO.VagaId);

			if (registros.Any(x => x.Ativa)) return null;

			var vagaDesocupada = await _carParkingHttpClient.ValidarVagaExistenteDesocupada(registroVagaDTO.VagaId);

			if (!vagaDesocupada) return null;

			// TODO: Atualizar flag da vaga no módulo CarParking
			var veiculoCadastrado = await _carParkingHttpClient.ValidarVeiculoCadastradoPorPlaca(registroVagaDTO.PlacaVeiculo);

			var registro = new RegistroVaga(registroVagaDTO.VagaId, registroVagaDTO.PlacaVeiculo, veiculoCadastrado);
		
			await _registroRepository.SalvarRegistroVaga(registro);
			await _registroRepository.SaveChangesAsync();

			var statusResult = await _carParkingHttpClient.AtualizarStatusVaga(registro, true);

			if (!statusResult) return null;

			return _mapper.Map<RegistroVagaViewModel>(registro);
		}

		public async Task<RegistroVagaViewModel?> RegistrarSaida(RegistroSaidaDTO registroSaidaDTO)
		{
			var registros = await _registroRepository.ObterRegistrosPorVagaIdOuPlaca(registroSaidaDTO.PlacaVeiculo);

			if (!registros.Any()) return null;

			var registro = registros.FirstOrDefault(x => x.PlacaVeiculo.ToLower().Equals(registroSaidaDTO.PlacaVeiculo.ToLower()));

			if (registro == null) return null;

			// TODO: Realizar a integração para retornar o valor caso não seja mensalista
			registro.RegistrarSaida();

			await _registroRepository.AtualizarRegistroVaga(registro);
			await _registroRepository.SaveChangesAsync();

			var statusResult = await _carParkingHttpClient.AtualizarStatusVaga(registro);

			if (!statusResult) return null;

			return _mapper.Map<RegistroVagaViewModel>(registro);
		}
	}
}
