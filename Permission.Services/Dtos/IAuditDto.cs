using System;
namespace Permission.Services.Dtos
{
	public interface IAuditDto
	{
        int? Id { get; set; }
        bool Deleted { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}

