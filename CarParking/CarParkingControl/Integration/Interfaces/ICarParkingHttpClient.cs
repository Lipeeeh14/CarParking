namespace CarParkingControl.Integration.Interfaces
{
	public interface ICarParkingHttpClient
	{
		Task<bool> ValidarVeiculoCadastradoPorPlaca(string placa);
	}
}
