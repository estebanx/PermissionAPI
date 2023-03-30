using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Permission.Models.Entities;
using Permission.Services.Dtos;
using Permission.Services.Services;

namespace PermissionAPI.Controllers
{
    [Route("api/[controller]")]
    public class PermissionTypesController : BaseController<PermissionType, PermissionTypeDto>
    {
        public PermissionTypesController(IPermissionTypeService permissionTypeService, IValidatorFactory validationFactory, IMapper mapper) : base(permissionTypeService, validationFactory, mapper)
        {
        }
    }
}

