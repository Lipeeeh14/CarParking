using CarParking.DTOs;
using CarParking.ViewModels;

namespace CarParking.Domain.Services.Interfaces
{
	public interface ISetorService
	{
		Task<IEnumerable<SetorViewModel>> ObterSetores();
		Task<SetorViewModel?> ObterSetorPorId(long id);
		Task<SetorViewModel?> SalvarSetor(CadastroSetorDTO setorDTO);
		Task<SetorViewModel?> AtualizarSetor(AtualizaSetorDTO setorDTO);
		Task<bool> DeletarSetor(long id);
	}
}
