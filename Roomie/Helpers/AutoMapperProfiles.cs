using AutoMapper;
using Roomie.Dtos.ForResponse;
using Roomie.Entity;

namespace Roomie.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            /*CreateMap<Post, ResPostDto>();
            *//*.ForMember(dest => dest.PostedBy, opt=>opt.MapFrom(src=>src.AppUserID));*/

            
            CreateMap<AppUser, AppUserDto>()
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture.Url));
            
          /*  CreateMap<AppUserRole, RoleDto>();*/
            CreateMap<AppUser, EmployeesInDepartment>();
            CreateMap<Department, DepartmentDto>();
       
            

            
            /*.ForMember(dest => dest.PostedBy.Id, opt => opt.MapFrom(src => src.PostedBy.Id))
            .ForMember(dest => dest.PostedBy.UserName, opt => opt.MapFrom(src => src.PostedBy.UserName))
            .ForMember(dest => dest.PostedBy.ContactNumber, opt => opt.MapFrom(src => src.PostedBy.PhoneNumber))
            .ForMember(dest => dest.PostedBy.ProfilePicture, opt => opt.MapFrom(src => src.PostedBy.ProfilePicture));*/

        }
    }
}
