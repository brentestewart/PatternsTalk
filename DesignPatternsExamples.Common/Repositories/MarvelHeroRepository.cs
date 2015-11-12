using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsExamples.Common.Models;
using Newtonsoft.Json;

namespace DesignPatternsExamples.Common.Repositories
{
	public class MarvelHeroRepository : IHeroRepository
	{
		private readonly string _heroFilePath;

		public MarvelHeroRepository(string filePath)
		{
			_heroFilePath = filePath;
		}
		public List<Hero> GetHeroes()
		{
			if (File.Exists(_heroFilePath))
			{
				using (var reader = new StreamReader(_heroFilePath))
				{
					var contents = reader.ReadToEnd();
					return JsonConvert.DeserializeObject<List<MarvelHero>>(contents).Cast<Hero>().ToList();
				}
			}

			return null;
		}
	}
}
