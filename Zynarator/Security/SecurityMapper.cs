using AutoMapper;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Ws.Dto;

namespace DotnetGenerator.Zynarator.Security;

public class SecurityMapperProfile : Profile
{
    public SecurityMapperProfile()
    {
        // roleUser mapper
        CreateMap<RoleUserDto, RoleUser>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
        CreateMap<RoleUser, RoleUserDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

        // role mapper
        CreateMap<RoleDto, Role>();
        CreateMap<Role, RoleDto>();

        // modelPermissionUser mapper
        CreateMap<ModelPermissionUserDto, ModelPermissionUser>()
            .ForMember(dest => dest.ActionPermission, opt => opt.MapFrom(src => src.ActionPermission))
            .ForMember(dest => dest.ModelPermission, opt => opt.MapFrom(src => src.ModelPermission))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
        CreateMap<ModelPermissionUser, ModelPermissionUserDto>()
            .ForMember(dest => dest.ActionPermission, opt => opt.MapFrom(src => src.ActionPermission))
            .ForMember(dest => dest.ModelPermission, opt => opt.MapFrom(src => src.ModelPermission))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

        // actionPermission mapper
        CreateMap<ActionPermissionDto, ActionPermission>();
        CreateMap<ActionPermission, ActionPermissionDto>();

        // modelPermission mapper
        CreateMap<ModelPermissionDto, ModelPermission>();
        CreateMap<ModelPermission, ModelPermissionDto>();

        // user mapper
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.RoleUsers, opt => opt.MapFrom(src => src.RoleUsers))
            .ForMember(dest => dest.ModelPermissionUsers, opt => opt.MapFrom(src => src.ModelPermissionUsers))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username));
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleUsers, opt => opt.MapFrom(src => src.RoleUsers))
            .ForMember(dest => dest.ModelPermissionUsers, opt => opt.MapFrom(src => src.ModelPermissionUsers))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName));
    }
}