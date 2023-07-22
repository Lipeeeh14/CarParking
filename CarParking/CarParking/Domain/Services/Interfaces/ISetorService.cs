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
		Task<VagaViewModel?> CadastrarVaga(CadastroVagaDTO vagaDTO);
		Task<bool> DeletarVaga(long setorId, int numero);
		Task<bool> AtualizarStatusVaga(VagaOcupadaDTO vagaDTO);
	}
}
