using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Permission.Services.Dtos;
using Permission.Services.Services;

namespace PermissionAPI.Controllers
{
    [Route("api/[controller]")]
    public class PermissionController : BaseController<Permission.Models.Entities.Permission, PermissionDto>
    {
        public PermissionController(IPermissionService permissionService, IValidatorFactory validationFactory, IMapper mapper) : base(permissionService, validationFactory, mapper)
        {
        }
    }
}

