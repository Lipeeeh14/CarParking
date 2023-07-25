using CarParkingControl.Domain.Models;

namespace CarParkingControl.Data.Repositories.Interfaces
{
	public interface IRegistroRepository
	{
		Task<IEnumerable<RegistroVaga>> ObterRegistros();
		Task<IEnumerable<RegistroVaga>> ObterRegistrosPorVagaIdOuPlaca(string? placaVeiculo = null, long? vagaId = null);
		Task<RegistroVaga?> ObterRegistroVagaPorId(long id);
		Task SalvarRegistroVaga(RegistroVaga registroVaga);
		Task AtualizarRegistroVaga(RegistroVaga registroVaga);
		Task SaveChangesAsync();
	}
}
