using CarModule.Data.Repositories.Interfaces;
using CarModule.Domain.Models;

namespace CarModule.Data.Repositories
{
	public abstract class BaseRepository : IBaseRepository
	{
		protected readonly CarContext _context;

		public BaseRepository(CarContext context) 
		{
			_context = context;
		}

		public async Task SaveChangesAsync() 
		{
			await _context.SaveChangesAsync();
		}
	}
}
