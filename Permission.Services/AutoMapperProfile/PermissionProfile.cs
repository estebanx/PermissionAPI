using System;
using AutoMapper;
using Permission.Models.Entities;
using Permission.Services.Dtos;

namespace Permission.Services.AutoMapperProfile
{
	public class PermissionProfile : Profile
	{
		public PermissionProfile()
		{
            CreateMap<PermissionType, PermissionTypeDto>();
            CreateMap<PermissionTypeDto, PermissionType>();

            CreateMap<Permission.Models.Entities.Permission, PermissionDto>()
                .ForMember(y => y.PermissionTypeDescription, x => x.MapFrom(y => y.PermissionType.Description));
            CreateMap<PermissionDto, Permission.Models.Entities.Permission>();

        }
	}
}

