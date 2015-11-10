using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsExamples.Common.Models;

namespace DesignPatternsExamples.HeroesWebService.Factories
{
	public class MarvelHeroFactory : IHeroFactory
	{
		private List<Hero> HeroList { get; set; }
		private int _currentIndex = 0;

		public int HeroCount => HeroList.Count;

		public MarvelHeroFactory()
		{
			BuildHeroList();
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
				new Hero {FirstName = "Natasha", LastName = "Romanova", HeroName = "Black Widow", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Steve", LastName = "Rogers", HeroName = "Captain America", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Scott", LastName = "Summers", HeroName = "Cyclops", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Matt", LastName = "Murdock", HeroName = "Daredevil", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Clint", LastName = "Barton", HeroName = "Hawkeye", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Bruce", LastName = "Banner", HeroName = "Hulk", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Johnny", LastName = "Storm", HeroName = "Human Torch", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Tony", LastName = "Stark", HeroName = "Ironman", ComicType = ComicType.Marvel},
				new Hero {FirstName = "Ororo", LastName = "Munroe", HeroName = "Storm", ComicType = ComicType.Marvel},
				new Hero {FirstName = "James", LastName = "Howlett", HeroName = "Wolverine", ComicType = ComicType.Marvel},
			};
		}

	}
}
