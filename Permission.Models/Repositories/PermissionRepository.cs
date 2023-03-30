using System;
using Microsoft.EntityFrameworkCore;
using Permission.Models.Context;

namespace Permission.Models.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission.Models.Entities.Permission>
    {
        public PermissionRepository(PermissionDataContext context) : base(context)
        {
            
        }

        public override IQueryable<Permission.Models.Entities.Permission> GetAll()
        {
            return base.GetAll().Include(x => x.PermissionType);
        }
    }
}

