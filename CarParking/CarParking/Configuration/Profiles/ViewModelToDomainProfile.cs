using AutoMapper;
using CarParking.Domain.Models;
using CarParking.DTOs;

namespace CarParking.Configuration.Profiles
{
	public class ViewModelToDomainProfile : Profile
	{
		public ViewModelToDomainProfile()
		{
			CreateMap<CadastroSetorDTO, Setor>()
				.ReverseMap();

			CreateMap<AtualizaSetorDTO, Setor>()
				.ReverseMap();
		}
	}
}
