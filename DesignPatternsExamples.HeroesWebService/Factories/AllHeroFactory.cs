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
				new Hero {FirstName = "Scott", LastName = "Lang", HeroName = "Ant-Man", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Arthur", LastName = "Curry", HeroName = "Aquaman", ComicType = ComicType.DC},
				new Hero {FirstName = "Ray", LastName = "Palmer", HeroName = "Atom", ComicType = ComicType.DC},
				new Hero {FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicType = ComicType.DC},
				new Hero {FirstName = "Natasha", LastName = "Romanova", HeroName = "Black Widow", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Steve", LastName = "Rogers", HeroName = "Captain America", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Scott", LastName = "Summers", HeroName = "Cyclops", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Matt", LastName = "Murdock", HeroName = "Daredevil", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Oliver", LastName = "Queen", HeroName = "Green Arrow", ComicType = ComicType.DC},
				new Hero {FirstName = "Hal", LastName = "Jordan", HeroName = "Green Lantern", ComicType = ComicType.DC},
				new Hero {FirstName = "Clint", LastName = "Barton", HeroName = "Hawkeye", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Carter", LastName = "Hall", HeroName = "Hawkman", ComicType = ComicType.DC},
				new Hero {FirstName = "Bruce", LastName = "Banner", HeroName = "Hulk", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Johnny", LastName = "Storm", HeroName = "Human Torch", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Tony", LastName = "Stark", HeroName = "Ironman", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicType = ComicType.DC},
				new Hero {FirstName = "Ororo", LastName = "Munroe", HeroName = "Storm", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Kara", LastName = "Zor-El", HeroName = "Supergirl", ComicType = ComicType.DC},
				new Hero {FirstName = "Clark", LastName = "Kent", HeroName = "Superman", ComicType = ComicType.DC},
				new Hero {FirstName = "Barry", LastName = "Allen", HeroName = "The Flash", ComicType = ComicType.DC},
				new Hero {FirstName = "James", LastName = "Howlett", HeroName = "Wolverine", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Diana", LastName = "Prince", HeroName = "Wonder Woman", ComicType = ComicType.DC},
			};
		}
	}
}
