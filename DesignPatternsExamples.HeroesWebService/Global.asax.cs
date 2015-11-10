using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DesignPatternsExamples.HeroesWebService.Factories;

namespace DesignPatternsExamples.HeroesWebService
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			RegisterHeroFactory();
		}

		private void RegisterHeroFactory()
		{
			var factoryName = ConfigurationManager.AppSettings["HeroFactoryClassName"];
			var factory = Assembly.GetExecutingAssembly().CreateInstance(factoryName) as IHeroFactory;
			Application["HeroFactory"] = factory;
		}
	}
}
