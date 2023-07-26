using CarParking.Domain.Models;

namespace CarParking.Data.Repositories.Interfaces
{
	public interface ISetorRepository : IBaseRepository
	{
		Task<IEnumerable<Setor>> ObterSetores();
		Task<Setor?> ObterSetorPorId(long id);
		Task<Setor?> ObterSetorPorSigla(string sigla);
		Task CadastrarSetor(Setor setor);
		Task AtualizarSetor(Setor setor);
		Task DeletarSetor(Setor setor);
		Task<Vaga?> ObterVagaPorId(long vagaId);
		Task AtualizarVaga(Vaga vaga);
	}
}
