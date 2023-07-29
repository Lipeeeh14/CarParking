using CarParkingControl.Domain.Models;
using CarParkingControl.Integration.DTOs;
using CarParkingControl.Integration.Interfaces;
using CarParkingControl.Integration.Responses;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace CarParkingControl.Integration
{
	public class CarParkingHttpClient : ICarParkingHttpClient
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;

		public CarParkingHttpClient(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}

		public async Task<bool> ValidarVeiculoCadastradoPorPlaca(string placa)
		{
			var endpoint = $"{_configuration["CarSettings:Url"]}/Proprietario/veiculo/{placa}";

			var response = await _httpClient.GetAsync(endpoint);

			// TODO: Mudar a validação, pois só será falso quando retornar 400
			if (!response.IsSuccessStatusCode)
				return false;

			return true;
		}

		public async Task<bool> ValidarVagaExistenteDesocupada(long vagaId)
		{
			var endpoint = $"{_configuration["CarParking:Url"]}/Setor/vaga/{vagaId}";

			var response = await _httpClient.GetAsync(endpoint);

			if (!response.IsSuccessStatusCode) return false;

			var result = await response.Content.ReadAsStringAsync();

			var vaga = JsonConvert.DeserializeObject<VagaResponse?>(result);

			return vaga != null && !vaga.Ocupado;
		}

		public async Task<bool> AtualizarStatusVaga(RegistroVaga registroVaga, bool vagaOcupada = false)
		{
			var endpoint = $"{_configuration["CarParking:Url"]}/Setor/vaga/status";

			var dto = new SetorVagaOcupadaDTO(registroVaga.VagaId, vagaOcupada);

			var httpContent = new StringContent(
				System.Text.Json.JsonSerializer.Serialize(dto),
				Encoding.UTF8,
				"application/json");

			var response = await _httpClient.PatchAsync(endpoint, httpContent);

			if (!response.IsSuccessStatusCode) return false;

			return true;
		}
	}
}
