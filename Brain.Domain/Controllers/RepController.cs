using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using Brain.Domain.Controllers;
using Brain.Domain.Models;
using Brain.Domain.Repositories;

namespace Brain.Domain.Controllers
{
	public class RepController : Controller
	{
		#region Fields

		private RepRepository _repController;

		#endregion

		#region Constructors

		public RepController(RepRepository repController)
		{
			_repController = repController;
		}

		#endregion

		/// <summary>
		/// Returns a login token if credentials are valid.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="rawPassword"></param>
		/// <returns></returns>
		public string GetAuthenticatedUsertokenByCredentials(string username, string rawPassword)
		{
			// hash the password
			var sha256 = SHA256.Create();
			byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(username + rawPassword));
			var hashedPassword = BitConverter.ToString(hashValue);

			var authenticatedUser = _repController.GetAuthenticatedUserByCredentials(username, hashedPassword);
			if (authenticatedUser == null)
			{
				return null;
			}

			hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(string.Format("{0}{1}", username, DateTime.Now)));
			var loginToken = BitConverter.ToString(hashValue);

			_repController.SaveLoginToken(authenticatedUser.repId, loginToken);
			return loginToken;
		}
	}
}
