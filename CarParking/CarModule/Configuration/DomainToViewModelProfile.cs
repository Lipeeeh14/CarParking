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
				.ReverseMap();
		}
	}
}
