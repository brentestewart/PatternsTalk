using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsExamples.Common.Models;

namespace DesignPatternsExamples.HeroesWebService.Factories
{
	public class DCHeroFactory : IHeroFactory
	{
		private List<Hero> HeroList { get; set; }
		private int _currentIndex = 0;

		public int HeroCount => HeroList.Count;

		public DCHeroFactory()
		{
			BuildHeroList();
		}

		public List<Hero> GetAllHeroes()
		{
			return HeroList;
		}

		public Hero CreateRandomHero()
		{
			if (_currentIndex >= HeroList.Count)
			{
				_currentIndex = 0;
			}

			return HeroList[_currentIndex++];
		}

		private void BuildHeroList()
		{
			HeroList = new List<Hero>
			{
				new DCHero {FirstName = "Arthur", LastName = "Curry", HeroName = "Aquaman", ComicType = ComicType.DC},
				new DCHero {FirstName = "Ray", LastName = "Palmer", HeroName = "Atom", ComicType = ComicType.DC},
				new DCHero {FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicType = ComicType.DC},
				new DCHero {FirstName = "Oliver", LastName = "Queen", HeroName = "Green Arrow", ComicType = ComicType.DC},
				new DCHero {FirstName = "Hal", LastName = "Jordan", HeroName = "Green Lantern", ComicType = ComicType.DC},
				new DCHero {FirstName = "Carter", LastName = "Hall", HeroName = "Hawkman", ComicType = ComicType.DC},
				new DCHero {FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicType = ComicType.DC},
				new DCHero {FirstName = "Kara", LastName = "Zor-El", HeroName = "Supergirl", ComicType = ComicType.DC},
				new DCHero {FirstName = "Clark", LastName = "Kent", HeroName = "Superman", ComicType = ComicType.DC},
				new DCHero {FirstName = "Barry", LastName = "Allen", HeroName = "The Flash", ComicType = ComicType.DC},
				new DCHero {FirstName = "Diana", LastName = "Prince", HeroName = "Wonder Woman", ComicType = ComicType.DC},
			};
		}
	}
}
