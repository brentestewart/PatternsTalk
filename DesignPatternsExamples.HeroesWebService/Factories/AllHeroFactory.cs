using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsExamples.Common.Models;

namespace DesignPatternsExamples.HeroesWebService.Factories
{
	public class AllHeroFactory : IHeroFactory
	{
		private List<Hero> HeroList { get; set; }
		private int _currentIndex = 0;

		public int HeroCount => HeroList.Count;

		public AllHeroFactory()
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
				new MarvelHero {FirstName = "Scott", LastName = "Lang", HeroName = "Ant-Man", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Natasha", LastName = "Romanova", HeroName = "Black Widow", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Steve", LastName = "Rogers", HeroName = "Captain America", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Scott", LastName = "Summers", HeroName = "Cyclops", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Matt", LastName = "Murdock", HeroName = "Daredevil", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Clint", LastName = "Barton", HeroName = "Hawkeye", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Bruce", LastName = "Banner", HeroName = "Hulk", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Johnny", LastName = "Storm", HeroName = "Human Torch", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Tony", LastName = "Stark", HeroName = "Ironman", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "Ororo", LastName = "Munroe", HeroName = "Storm", ComicType = ComicType.Marvel},
				new MarvelHero {FirstName = "James", LastName = "Howlett", HeroName = "Wolverine", ComicType = ComicType.Marvel},
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
