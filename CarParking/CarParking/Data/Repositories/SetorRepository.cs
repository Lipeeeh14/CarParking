using CarParking.Data.Repositories.Interfaces;
using CarParking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarParking.Data.Repositories
{
	public class SetorRepository : BaseRepository, ISetorRepository
	{
		public SetorRepository(CarParkingContext context) 
			: base(context)
		{
		}

		public async Task<IEnumerable<Setor>> ObterSetores()
		{
			return await _context.Setor
				.Include(s => s.Vagas)
				.ToListAsync();
		}

		public async Task<Setor?> ObterSetorPorId(long id)
		{
			return await _context.Setor
				.Include(s => s.Vagas)
				.FirstOrDefaultAsync(s => s.Id == id);
		}

		public async Task<Setor?> ObterSetorPorSigla(string sigla)
		{
			return await _context.Setor
				.FirstOrDefaultAsync(s => s.Sigla.ToLower().Equals(sigla.ToLower()));
		}

		public async Task CadastrarSetor(Setor setor)
		{
			await Task.Run(() => _context.Setor.Add(setor));
		}

		public async Task AtualizarSetor(Setor setor)
		{
			await Task.Run(() => _context.Setor.Update(setor));
		}

		public async Task DeletarSetor(Setor setor)
		{
			await Task.Run(() => _context.Remove(setor));
		}
	}
}
