using AutoMapper;
using Carvajal.Api.Dtos;
using Carvajal.Domain.Models;

namespace Carvajal.Api.Helpers.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<TypeIdentificationDto, TypeIdentification>()
                .ForMember(x => x.Users, opt => opt.Ignore());
        }
    }
}
