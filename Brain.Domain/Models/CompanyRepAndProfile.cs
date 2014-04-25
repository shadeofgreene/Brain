using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Web;

namespace Brain.Domain.Models
{
	public class CompanyRepAndProfile
	{
		public long RepId { get; set; }
		public string RepFirstName { get; set; }
		public string RepLastName { get; set; }
		public string RepCellNumber { get; set; }
		public string RepEmail { get; set; }
		public string LoginToken { get; set; }
		public int CompanyRepProfileId { get; set; }
		public DateTime? LastAuthentication { get; set; }
		public int NumberOfDaysTokenExpires { get; set; }
	}
}