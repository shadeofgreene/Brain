using System.Web.Mvc;

namespace Brain.Api.Areas.Api
{
	public class ApiAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Api";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"Api_default",
				"Api/v1/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
