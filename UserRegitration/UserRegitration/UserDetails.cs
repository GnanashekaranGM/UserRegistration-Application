using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace UserRegitration.Model
{
	public class UserDetails
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string Name { get; set; }

		[Unique]
		public string Email { get; set; }

		public string Password { get; set; }
	}
}

