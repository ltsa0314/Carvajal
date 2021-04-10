using AutoMapper;
using Carvajal.Api.Dtos;
using Carvajal.Domain.Models;

namespace Carvajal.Api.Helpers.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<TypeIdentification, TypeIdentificationDto>();

        }
    }
}
