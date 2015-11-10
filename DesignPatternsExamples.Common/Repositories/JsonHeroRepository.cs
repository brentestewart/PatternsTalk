﻿using System;
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
	public class JsonHeroRepository : IHeroRepository
	{
		private readonly string _heroFilePath;

		public JsonHeroRepository(string filePath)
		{
			_heroFilePath = filePath;
		}
		public List<Hero> GetHeroes()
		{
			using (var reader = new StreamReader(_heroFilePath))
			{
				var contents = reader.ReadToEnd();
				var heroes = JsonConvert.DeserializeObject<List<Hero>>(contents);
				return heroes;
			}
		}
	}
}
