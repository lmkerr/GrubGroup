using System;
using GrubGroup.Domain.Models.Base;

namespace GrubGroup.Domain.Models.Identity
{
	public class Role : BaseModel
	{
		public Guid RoleId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
