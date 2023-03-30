using System;
namespace Permission.Services.Dtos
{
    public class PermissionTypeDto : IAuditDto
    {
        public int? Id { get; set; }
        public string Description { get; set; }        
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}