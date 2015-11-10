using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsExamples.Common.Models;

namespace DesignPatternsExamples.Common.Repositories
{
	public class CachingRepository : IHeroRepository
	{
		private readonly IHeroRepository _repository;
		private DateTime _cacheTimeStamp;
		private List<Hero> _cachedHeroes;
		private const int CacheDuration = 60;

		public CachingRepository(IHeroRepository repository)
		{
			_repository = repository;
		}

		public List<Hero> GetHeroes()
		{
			if (_cachedHeroes == null || _cacheTimeStamp.AddSeconds(CacheDuration) < DateTime.Now)
			{
				_cachedHeroes = _repository.GetHeroes();
				_cacheTimeStamp = DateTime.Now;
			}

			return _cachedHeroes;
		}
	}
}
