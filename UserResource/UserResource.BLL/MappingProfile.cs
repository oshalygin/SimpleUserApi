using AutoMapper;
using ExternalSynchronization;
using UserResource.DAL.Entities;

namespace UserResource.BLL
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User, ExternalUser>().ReverseMap();
        }
    }
}