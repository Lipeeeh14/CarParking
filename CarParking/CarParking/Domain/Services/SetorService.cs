using AutoMapper;
using CarParking.Data.Repositories.Interfaces;
using CarParking.Domain.Models;
using CarParking.Domain.Services.Interfaces;
using CarParking.DTOs;
using CarParking.ViewModels;

namespace CarParking.Domain.Services
{
	public class SetorService : ISetorService
	{
		private readonly ISetorRepository _setorRepository;
		private IMapper _mapper;

		public SetorService(ISetorRepository setorRepository, IMapper mapper)
		{
			_setorRepository = setorRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<SetorViewModel>> ObterSetores()
		{
			var setores = await _setorRepository.ObterSetores();
			return _mapper.Map<IEnumerable<SetorViewModel>>(setores);
		}

		public async Task<SetorViewModel?> ObterSetorPorId(long id)
		{
			var setor = await _setorRepository.ObterSetorPorId(id);
			return _mapper.Map<SetorViewModel>(setor);
		}

		public async Task<SetorViewModel?> SalvarSetor(CadastroSetorDTO setorDTO)
		{
			var setor = await _setorRepository.ObterSetorPorSigla(setorDTO.Sigla);

			if (setor != null) return null;

			setor = _mapper.Map<Setor>(setorDTO);

			await _setorRepository.CadastrarSetor(setor);
			await _setorRepository.SaveChangesAsync();

			return _mapper.Map<SetorViewModel>(setor);
		}

		public async Task<SetorViewModel?> AtualizarSetor(AtualizaSetorDTO setorDTO)
		{
			var setor = await _setorRepository.ObterSetorPorId(setorDTO.Id);

			if (setor == null) return null;

			setor.Atualizar(setorDTO.Sigla);

			await _setorRepository.AtualizarSetor(setor);
			await _setorRepository.SaveChangesAsync();

			return _mapper.Map<SetorViewModel>(setor);
		}

		public async Task<bool> DeletarSetor(long id)
		{
			var setor = await _setorRepository.ObterSetorPorId(id);

			if (setor == null) return false;

			await _setorRepository.DeletarSetor(setor);
			await _setorRepository.SaveChangesAsync();

			return true;
		}

		public async Task<VagaViewModel?> ObterVagaPorId(long vagaId)
		{
			var vaga = await _setorRepository.ObterVagaPorId(vagaId);
			return _mapper.Map<VagaViewModel>(vaga);
		}

		public async Task<VagaViewModel?> CadastrarVaga(CadastroVagaDTO vagaDTO)
		{
			var setor = await _setorRepository.ObterSetorPorId(vagaDTO.SetorId);

			if (setor == null) return null;

			if (setor.VagaExistente(vagaDTO.Numero)) return null;

			var vaga = _mapper.Map<Vaga>(vagaDTO);

			setor.AdicionarVaga(vaga);

			await _setorRepository.AtualizarSetor(setor);
			await _setorRepository.SaveChangesAsync();

			return _mapper.Map<VagaViewModel>(vaga);
		}

		public async Task<bool> DeletarVaga(long setorId, int numero)
		{
			var setor = await _setorRepository.ObterSetorPorId(setorId);

			if (setor == null) return false;

			setor.RemoverVaga(numero);

			await _setorRepository.AtualizarSetor(setor);
			await _setorRepository.SaveChangesAsync();

			return true;
		}

		public async Task<bool> AtualizarStatusVaga(VagaOcupadaDTO vagaDTO)
		{
			var vaga = await _setorRepository.ObterVagaPorId(vagaDTO.VagaId);

			if (vaga == null) return false;

			vaga.AtualizarStatus(vagaDTO.Ocupado);

			await _setorRepository.AtualizarVaga(vaga);
			await _setorRepository.SaveChangesAsync();

			return true;
		}
	}
}
