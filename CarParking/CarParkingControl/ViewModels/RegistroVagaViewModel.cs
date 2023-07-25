namespace CarParkingControl.ViewModels
{
	public record RegistroVagaViewModel(long Id, long VagaId, string PlacaCarro, 
		DateTime DataEntrada, DateTime? DataSaida, bool Mensalista, decimal? Valor);
}
