using System.Collections.Generic;
using DesignPatternsExamples.Common.Models;

namespace DesignPatternsExamples.Common.Repositories
{
	public interface IHeroRepository
	{
		List<Hero> GetHeroes();
	}
}
