using System;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Permission.Models.Repositories;
using Permission.Services.Dtos;

namespace Permission.Services.Services
{
    public interface IPermissionService : IBaseService<Permission.Models.Entities.Permission, PermissionDto>
    {
    }

    public class PermissionService : BaseService<Permission.Models.Entities.Permission, PermissionDto>, IPermissionService
    {
        public PermissionService(IMapper mapper, IValidator<PermissionDto> validator, IRepositoryBase<Permission.Models.Entities.Permission> baseRepository) : base(mapper, validator, baseRepository)
        {

        }

        public override IList<PermissionDto> GetAll()
        {
            var list = _repository.GetAll().Include(x => x.PermissionType).ToList();
            IList<PermissionDto> listDto = _mapper.Map<IList<PermissionDto>>(list);
            return listDto;
        }
    }
}

