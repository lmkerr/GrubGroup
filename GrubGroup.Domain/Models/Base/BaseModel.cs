using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrubGroup.Domain.Models.Base
{
	public class BaseModel
	{
		public bool Deleted { get; set; }
		public DateTime DeletedOn { get; set; }
		public Guid CreatedById { get; set; }
		public string CreatedByIp { get; set; }
		public DateTime CreatedOn { get; set; }
		public Guid ModifiedById { get; set; }
		public DateTime ModifiedAt { get; set; }
		public string ModifiedByIp { get; set; }
	}
}
