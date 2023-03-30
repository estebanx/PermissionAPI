namespace Permission.Models.Entities
{
    public class PermissionType : IAudit
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

