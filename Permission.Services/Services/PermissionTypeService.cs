using System;
using AutoMapper;
using FluentValidation;
using Permission.Models.Entities;
using Permission.Models.Repositories;
using Permission.Services.Dtos;

namespace Permission.Services.Services
{
    public interface IPermissionTypeService : IBaseService<PermissionType, PermissionTypeDto>
    {
    }

    public class PermissionTypeService : BaseService<PermissionType, PermissionTypeDto>, IPermissionTypeService
    {
        public PermissionTypeService(IMapper mapper, IValidator<PermissionTypeDto> validator, IRepositoryBase<PermissionType> baseRepository) : base(mapper, validator, baseRepository)
        {

        }
    }
}

