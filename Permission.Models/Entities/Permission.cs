using System;
namespace Permission.Models.Entities
{
    public class Permission : IAudit
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }
        public virtual PermissionType? PermissionType { get; set; }        
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}