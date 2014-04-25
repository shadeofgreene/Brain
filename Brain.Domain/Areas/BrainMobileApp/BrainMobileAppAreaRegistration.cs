using System.Web.Mvc;

namespace Brain.Domain.Areas.BrainMobileApp
{
	public class BrainMobileAppAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "BrainMobileApp";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"BrainMobileApp_default",
				"BrainMobileApp/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
