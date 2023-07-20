using CarParking.Data.Repositories.Interfaces;

namespace CarParking.Data.Repositories
{
	public class BaseRepository : IBaseRepository
	{
		protected readonly CarParkingContext _context;

		public BaseRepository(CarParkingContext context)
		{
			_context = context;
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
