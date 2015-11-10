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
	public class WebApiHeroRepository : IHeroRepository
	{
		private readonly string _serviceBaseUrl;

		public WebApiHeroRepository(string servicePath)
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
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var response = client.GetAsync("api/Heroes").Result;
					if (response.IsSuccessStatusCode)
					{
						var content = response.Content.ReadAsStringAsync().Result;
						return JsonConvert.DeserializeObject<List<Hero>>(content);
					}
				}

			}
			catch (TimeoutException)
			{
				// service is not available
			}

			return new List<Hero>() { new Hero() { HeroName = "Service not available..." } };
		}
	}
}
