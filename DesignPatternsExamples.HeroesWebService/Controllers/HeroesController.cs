using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using DesignPatternsExamples.Common.Models;
using DesignPatternsExamples.HeroesWebService.Factories;

namespace DesignPatternsExamples.HeroesWebService.Controllers
{
    public class HeroesController : ApiController
    {
	    readonly IHeroFactory _heroFactory;
	    private readonly int _numOfHeroesToReturn = 4;

		public HeroesController(IHeroFactory heroFactory)
	    {
		    _heroFactory = LoadHeroFactory();
	    }

	    public List<Hero> Get()
	    {
		    var heroList = new List<Hero>();
		    var count = _heroFactory.HeroCount;
		    for (int i = 0; i < count; i++)
		    {
				heroList.Add(_heroFactory.CreateRandomHero());
			}

			return heroList;
	    }

	    private IHeroFactory LoadHeroFactory()
	    {
		    var factoryName = ConfigurationManager.AppSettings["HeroFactoryClassName"];
			return Assembly.GetExecutingAssembly().CreateInstance(factoryName) as IHeroFactory;
	    }

	    private List<Hero> GetDCHeroList()
	    {
		    return new List<Hero>
		    {
			    new Hero {FirstName = "Hal", LastName = "Jordan", HeroName = "Green Lantern"},
			    new Hero {FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman"},
			    new Hero {FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman"},
			    new Hero {FirstName = "Clark", LastName = "Kent", HeroName = "Superman"}
		    };
	    }
    }
}
