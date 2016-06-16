using System;
namespace Shared
{
	public class Professional
	{
		private string mail;
		private string password;
		private string name;


		public Professional(string _mail, string _password, string _name)
		{
			mail = _mail;
			password = _password;
			name = _name;

		}

		// Gets and Sets

		public string Mail
		{
			get
			{
				return mail;
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
		}
	}
}

