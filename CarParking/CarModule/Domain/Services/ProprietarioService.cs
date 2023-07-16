using AutoMapper;
using CarModule.Data.Repositories.Interfaces;
using CarModule.Domain.Models;
using CarModule.Domain.Services.Interfaces;
using CarModule.DTOs;
using CarModule.ViewModels;

namespace CarModule.Domain.Services
{
	public class ProprietarioService : IProprietarioService
	{
		private readonly IProprietarioRepository _proprietarioRepository;
		private IMapper _mapper;

		public ProprietarioService(IProprietarioRepository proprietarioRepository, IMapper mapper)
		{
			_proprietarioRepository = proprietarioRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProprietarioViewModel>> ConsultarProprietarios()
		{
			var proprietarios = await _proprietarioRepository.ConsultarProprietarios();
			return _mapper.Map<IEnumerable<ProprietarioViewModel>>(proprietarios);
		}

		public async Task<ProprietarioViewModel?> ObterProprietarioPorId(long id)
		{
			var proprietario = await _proprietarioRepository.ObterProprietarioPorId(id);
			return _mapper.Map<ProprietarioViewModel>(proprietario);
		}

		public async Task<ProprietarioViewModel?> SalvarProprietario(CadastroProprietarioDTO proprietarioDTO)
		{
			var proprietario = _mapper.Map<Proprietario>(proprietarioDTO);

			await _proprietarioRepository.SalvarProprietario(proprietario);
			await _proprietarioRepository.SaveChangesAsync();

			return _mapper.Map<ProprietarioViewModel>(proprietario);
		}

		public async Task<ProprietarioViewModel?> AtualizarProprietario(AtualizaProprietarioDTO proprietarioDTO)
		{
			var proprietario = await _proprietarioRepository.ObterProprietarioPorId(proprietarioDTO.Id);

			if (proprietario == null) return null;

			proprietario.Atualizar(proprietarioDTO.Nome, proprietarioDTO.Cpf);

			await _proprietarioRepository.AtualizarProprietario(proprietario);
			await _proprietarioRepository.SaveChangesAsync();

			return _mapper.Map<ProprietarioViewModel>(proprietario);
		}

		public async Task<bool> DeletarProprietario(long id)
		{
			var proprietario = await _proprietarioRepository.ObterProprietarioPorId(id);

			if (proprietario == null) return false;

			await _proprietarioRepository.DeletarProprietario(proprietario);
			await _proprietarioRepository.SaveChangesAsync();

			return true;
		}
	}
}
