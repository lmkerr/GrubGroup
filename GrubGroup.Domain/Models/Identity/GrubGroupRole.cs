using System;
using Microsoft.AspNet.Identity;

namespace GrubGroup.Domain.Models.Identity
{
	public class GrubGroupRole : IRole
	{
		public GrubGroupRole(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
        public string Name { get; set; }
	}
}
