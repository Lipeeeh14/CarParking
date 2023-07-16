using CarModule.Domain.Models;

namespace CarModule.Data.Repositories.Interfaces
{
	public interface IProprietarioRepository : IBaseRepository
	{
		Task<IEnumerable<Proprietario>> ConsultarProprietarios();
		Task<Proprietario?> ObterProprietarioPorId(long id);
		Task SalvarProprietario(Proprietario proprietario);
		Task AtualizarProprietario(Proprietario proprietario);
		Task DeletarProprietario(Proprietario proprietario);
	}
}
