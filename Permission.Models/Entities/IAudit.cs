using System;
namespace Permission.Models.Entities
{
	public interface IAudit
	{
		int Id { get; set; }
		bool Deleted { get; set; }
		DateTime CreatedDate { get; set; }
		DateTime ModifiedDate { get; set; }
	}
}

