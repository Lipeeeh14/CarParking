namespace CarParking.ViewModels
{
	public record SetorViewModel(long Id, string Sigla, IEnumerable<VagaViewModel> Vagas);	
}
