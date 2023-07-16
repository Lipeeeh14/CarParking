using AutoMapper;
using CarModule.Domain.Models;
using CarModule.DTOs;

namespace CarModule.Configuration
{
	public class ViewModelToDomainProfile : Profile
	{
		public ViewModelToDomainProfile() 
		{
			CreateMap<CadastroProprietarioDTO, Proprietario>()
				.ReverseMap();

			CreateMap<AtualizaProprietarioDTO, Proprietario>()
				.ReverseMap();
		}
	}
}
