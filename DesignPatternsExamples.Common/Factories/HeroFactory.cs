using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsExamples.Common.Models;
using DesignPatternsExamples.Common.Repositories;

namespace DesignPatternsExamples.Common.Factories
{
	public static class HeroFactory
	{
		private static Dictionary<RepositoryType, IHeroRepository> Repositories { get; set; }

		static HeroFactory()
		{
			Repositories = new Dictionary<RepositoryType, IHeroRepository>();
		}

		public static List<Hero> GetHeroes(RepositoryType repositoryType)
		{
			if(!Repositories.ContainsKey(repositoryType))
				throw new ArgumentOutOfRangeException();

			var repository = Repositories[repositoryType];
			return repository.GetHeroes();
		}

		public static void AddRepository(RepositoryType repositoryType, IHeroRepository repository)
		{
			var cachingRepository = new CachingRepository(repository);
			if (Repositories.ContainsKey(repositoryType))
			{
				Repositories[repositoryType] = cachingRepository;
			}
			else
			{
				Repositories.Add(repositoryType, cachingRepository);
			}
		}
	}
}
