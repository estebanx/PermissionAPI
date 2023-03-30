using System;
using Microsoft.EntityFrameworkCore;
using Permission.Models.Entities;

namespace Permission.Models.Context
{
	public class PermissionDataContext : DbContext
	{
		public PermissionDataContext(DbContextOptions<PermissionDataContext> options) : base(options)
        {

		}

        public DbSet<Permission.Models.Entities.Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Permission.Models.Entities.Permission>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<PermissionType>().HasQueryFilter(x => !x.Deleted);

            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType { Id = 1, Description = "Enfermedad", CreatedDate = DateTime.Now },
                new PermissionType { Id = 2, Description = "Diligencias", CreatedDate = DateTime.Now },
                new PermissionType { Id = 3, Description = "Otros", CreatedDate = DateTime.Now }
                );
        }

    }
}