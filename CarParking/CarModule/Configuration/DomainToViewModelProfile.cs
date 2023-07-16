using AutoMapper;
using CarModule.Domain.Models;
using CarModule.ViewModels;

namespace CarModule.Configuration
{
	public class DomainToViewModelProfile : Profile
	{
		public DomainToViewModelProfile()
		{
			CreateMap<Proprietario, ProprietarioViewModel>()
				.ForMember(src => src.Veiculos, opt => opt.MapFrom(src => src.Veiculos))
				.ReverseMap();

			CreateMap<Veiculo, VeiculoViewModel>()
				.ReverseMap();
		}
	}
}
