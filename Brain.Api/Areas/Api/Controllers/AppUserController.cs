using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Brain.Domain;
using Brain.Domain.Controllers;
using ApiController = System.Web.Http.ApiController;

namespace Brain.Api.Areas.Api.Controllers
{
	public class AppUserController : ApiController
	{
		#region Fields

		private Domain.Controllers.RepController _repController;

		#endregion

		#region Constructors

		[Route("v1/loginToken")]
		public AppUserController(RepController repController)
		{
			_repController = repController;
		}

		#endregion

		#region Public Methods


		#endregion


	}
}
