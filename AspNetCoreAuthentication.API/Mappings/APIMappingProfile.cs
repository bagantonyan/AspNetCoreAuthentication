using AspNetCoreAuthentication.API.Models.Users;
using AspNetCoreAuthentication.BLL.Models.Users;
using AutoMapper;

namespace AspNetCoreAuthentication.API.Mappings
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<RegisterUserRequestModel, RegisterUserRequestDTO>();
            CreateMap<LoginUserRequestModel, LoginUserRequestDTO>();
        }
    }
}
