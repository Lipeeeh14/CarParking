using CarParkingControl.Integration.Interfaces;

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

		public Task<bool> ValidarVagaExistenteDesocupada(long vagaId)
		{
			var endpoint = $"{_configuration["CarParking:Url"]}/Setor/vaga"
		}
	}
}
