using AutoMapper;
using UserResource.DAL.Entities;
using UserResource.Models;

namespace UserResource
{
    public class MappingProfile: Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<User, UserViewModel>();

            AutoMapper.Mapper.CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.IsDeleted, options => options.Ignore())
                .ForMember(dest => dest.IsActive, options => options.Ignore());

            AutoMapper.Mapper.CreateMap<UserContactInformation, UserContactInformationViewModel>()
                .ReverseMap();

        }
    }
}