using AutoMapper;
using CarParking.Domain.Models;
using CarParking.ViewModels;

namespace CarParking.Configuration.Profiles
{
	public class DomainToViewModelProfile : Profile
	{
		public DomainToViewModelProfile() 
		{
			CreateMap<Setor, SetorViewModel>()
				.ReverseMap();

			CreateMap<Vaga, VagaViewModel>()
				.ReverseMap();
		}
	}
}
