using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using DesignPatternsExamples.Common.Models;
using DesignPatternsExamples.Common.Repositories;
using Newtonsoft.Json;

namespace DesignPatternsExamples.HeroApp.Views
{
	public partial class HeroSearchView : UserControl
	{

		public HeroSearchView()
		{
			InitializeComponent();
		}

		private void ApiButton_OnClick(object sender, RoutedEventArgs e)
		{
			var servicePath = Properties.Settings.Default.WebApiUrl;
			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(servicePath);
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var response = client.GetAsync("api/Heroes").Result;
					if (response.IsSuccessStatusCode)
					{
						var content = response.Content.ReadAsStringAsync().Result;
					 	HeroList.ItemsSource = JsonConvert.DeserializeObject<List<Hero>>(content);
						return;
					}
				}

			}
			catch (Exception)
			{
				// service is not available
			}

			HeroList.ItemsSource = new List<Hero>() { new Hero() { HeroName = "Service down..." } };
		}

		private void JsonButton_OnClick(object sender, RoutedEventArgs e)
		{
					var filePath = Properties.Settings.Default.HeroFilePath;
			if (File.Exists(filePath))
			{
				using (var reader = new StreamReader(filePath))
				{
					var contents = reader.ReadToEnd();
					HeroList.ItemsSource = JsonConvert.DeserializeObject<List<Hero>>(contents);
					return;
				}
			}

			HeroList.ItemsSource = new List<Hero> { new Hero { HeroName = "File not found" } };
		}

		private void ClearButton_OnClick(object sender, RoutedEventArgs e)
		{
		}
	}
}
