using CarParkingControl.Data.Repositories.Interfaces;
using CarParkingControl.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarParkingControl.Data.Repositories
{
	public class RegistroRepository : IRegistroRepository
	{
		private readonly CarParkingControlContext _context;

		public RegistroRepository(CarParkingControlContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<RegistroVaga>> ObterRegistros()
		{
			return await _context.RegistroVaga
				.ToListAsync();
		}

		public async Task<IEnumerable<RegistroVaga>> ObterRegistrosPorVagaIdOuPlaca(string? placaVeiculo = null, long? vagaId = null)
		{
			var query = _context.RegistroVaga
				.Where(x => x.Id > 0);

			if (vagaId.HasValue)
				query = query.Where(x => x.VagaId == vagaId.Value);

			if (!string.IsNullOrEmpty(placaVeiculo))
				query = query.Where(x => x.PlacaVeiculo.ToLower().Equals(placaVeiculo.ToLower()));

			var result = await _context.RegistroVaga.ToListAsync();

			if (result == null)
				return new List<RegistroVaga>();

			return result;
		}

		public async Task<RegistroVaga?> ObterRegistroVagaPorId(long id)
		{
			return await _context.RegistroVaga
				.FirstOrDefaultAsync(r => r.Id == id);
		}

		public async Task SalvarRegistroVaga(RegistroVaga registroVaga)
		{
			await Task.Run(() => _context.RegistroVaga.Add(registroVaga));
		}

		public async Task AtualizarRegistroVaga(RegistroVaga registroVaga)
		{
			await Task.Run(() => _context.RegistroVaga.Update(registroVaga));
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
