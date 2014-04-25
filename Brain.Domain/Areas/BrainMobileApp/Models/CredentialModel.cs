using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brain.Domain.Areas.BrainMobileApp.Models
{
	public class CredentialModel
	{
		public string Username { get; set; }
		public string Password { get; private set; }
	}
}