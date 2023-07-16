using CarModule.Data.Repositories.Interfaces;
using CarModule.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarModule.Data.Repositories
{
	public class ProprietarioRepositoy : BaseRepository, IProprietarioRepository
	{
		public ProprietarioRepositoy(CarContext context) 
			: base(context)
		{
		}

		public async Task<IEnumerable<Proprietario>> ConsultarProprietarios()
		{
			return await _context.Proprietario
				.Include(p => p.Veiculos)
				.ToListAsync();
		}

		public async Task<Proprietario?> ObterProprietarioPorId(long id)
		{
			return await _context.Proprietario
				.Include(p => p.Veiculos)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task SalvarProprietario(Proprietario proprietario)
		{
			await Task.Run(() => _context.Proprietario.Add(proprietario));
		}

		public async Task AtualizarProprietario(Proprietario proprietario)
		{
			await Task.Run(() => _context.Proprietario.Update(proprietario));
		}

		public async Task DeletarProprietario(Proprietario proprietario)
		{
			await Task.Run(() => _context.Remove(proprietario));
		}
	}
}
