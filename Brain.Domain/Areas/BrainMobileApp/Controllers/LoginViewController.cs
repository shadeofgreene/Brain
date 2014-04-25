using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Brain.Domain.Areas.BrainMobileApp.Models;
using Brain.Domain.Controllers;

namespace Brain.Domain.Areas.BrainMobileApp.Controllers
{
	public class LoginViewController : Controller
	{
		#region Fields

		private Domain.Controllers.RepController _repController;

		#endregion

		#region Constructors

		public LoginViewController(RepController repController)
		{
			_repController = repController;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Get login token (user tries logging in)
		/// </summary>
		/// <param name="credentials"></param>
		/// <returns></returns>
		public JsonResult GetLoginToken(CredentialModel credentials)
		{
			var token = _repController.GetAuthenticatedUsertokenByCredentials(credentials.Username, credentials.Password);

			return Json(token, JsonRequestBehavior.AllowGet);
		}

		#endregion
	}
}
