using AutoMapper;
using CarParkingControl.Domain.Models;
using CarParkingControl.ViewModels;

namespace CarParkingControl.Configuration.Profiles
{
	public class DomainToViewModelProfile : Profile
	{
		public DomainToViewModelProfile() 
		{
			CreateMap<RegistroVaga, RegistroVagaViewModel>()
				.ReverseMap();
		}
	}
}
