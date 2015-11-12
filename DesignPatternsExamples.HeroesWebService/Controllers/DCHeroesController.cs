using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using DesignPatternsExamples.Common.Models;
using DesignPatternsExamples.HeroesWebService.Factories;

namespace DesignPatternsExamples.HeroesWebService.Controllers
{
    public class DCHeroesController : ApiController
    {
	    readonly IHeroFactory _heroFactory;

		public DCHeroesController()
	    {
		    _heroFactory = HttpContext.Current.Application["HeroFactory"] as IHeroFactory;
	    }

	    public List<Hero> Get()
	    {
		    return _heroFactory.GetAllHeroes();
	    }
    }
}
