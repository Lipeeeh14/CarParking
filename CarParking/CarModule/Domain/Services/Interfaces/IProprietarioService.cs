using CarModule.DTOs;
using CarModule.ViewModels;

namespace CarModule.Domain.Services.Interfaces
{
	public interface IProprietarioService
	{
		Task<IEnumerable<ProprietarioViewModel>> ConsultarProprietarios();
		Task<ProprietarioViewModel?> ObterProprietarioPorId(long id);
		Task<ProprietarioViewModel?> SalvarProprietario(CadastroProprietarioDTO proprietarioDTO);
		Task<ProprietarioViewModel?> AtualizarProprietario(AtualizaProprietarioDTO proprietarioDTO);
		Task<bool> DeletarProprietario(long id);
	}
}
