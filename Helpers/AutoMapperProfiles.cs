using AutoMapper;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();

            //custom mapiranja
            CreateMap<Administrator, AdminDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<Member, MemberDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<ManagerS, ManagerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<Receptionist, ReceptionistDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<RegistrationRequest, RegistrationRequestDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<TrainerUser, TrainerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ValueDto, UserData>();


        }
    }
}
