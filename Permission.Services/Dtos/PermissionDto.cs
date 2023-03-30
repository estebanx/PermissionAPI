using System;
namespace Permission.Services.Dtos
{
	public class PermissionDto : IAuditDto
	{
        public int? Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string PermissionTypeDescription { get; set; }
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }        
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

