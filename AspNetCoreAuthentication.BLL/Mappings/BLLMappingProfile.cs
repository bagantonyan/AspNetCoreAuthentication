using AspNetCoreAuthentication.BLL.Models.Users;
using AspNetCoreAuthentication.DAL.Entities.Users;
using AutoMapper;

namespace AspNetCoreAuthentication.BLL.Mappings
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<RegisterUserRequestDTO, User>();
        }
    }
}
