using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsExamples.Common.Models;
using Newtonsoft.Json;

namespace DesignPatternsExamples.Common.Repositories
{
	public class DCHeroRepository : IHeroRepository
	{
		private readonly string _serviceBaseUrl;

		public DCHeroRepository(string servicePath)
		{
			_serviceBaseUrl = servicePath;
		}
		public List<Hero> GetHeroes()
		{
			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(_serviceBaseUrl);
					var response = client.GetAsync("api/DCHeroes").Result;
					if (response.IsSuccessStatusCode)
					{
						var content = response.Content.ReadAsStringAsync().Result;
						return JsonConvert.DeserializeObject<List<DCHero>>(content).Cast<Hero>().ToList();
					}
				}

			}
			catch (Exception)
			{
				// service is not available
			}

			return null;
		}
	}
}
