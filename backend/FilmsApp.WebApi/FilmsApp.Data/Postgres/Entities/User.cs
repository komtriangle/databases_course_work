﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsApp.Data.Postgres.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }

		public virtual ICollection<UserRoles> Roles { get; set; }

	}
}
