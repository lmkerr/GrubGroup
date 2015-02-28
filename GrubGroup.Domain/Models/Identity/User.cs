using System;
using GrubGroup.Domain.Models.Base;

namespace GrubGroup.Domain.Models.Identity
{
	public class User : BaseModel
	{
		public Guid UserId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Salt { get; set; }
	}
}
