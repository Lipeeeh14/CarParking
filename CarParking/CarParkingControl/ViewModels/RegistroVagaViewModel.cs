namespace CarParkingControl.ViewModels
{
	public record RegistroVagaViewModel(long Id, long VagaId, string PlacaVeiculo, 
		DateTime DataEntrada, DateTime? DataSaida, bool Mensalista, decimal? Valor);
}
