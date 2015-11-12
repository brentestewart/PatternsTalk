using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DesignPatternsExamples.Common.Models;
using DesignPatternsExamples.Common.Repositories;
using Newtonsoft.Json;

namespace DesignPatternsExamples.HeroApp.Views
{
	public partial class HeroSearchView : UserControl
	{
		private readonly IHeroRepository _jsonRepository;
		private readonly IHeroRepository _webApiRepository;
		public HeroSearchView()
		{
			InitializeComponent();
			_jsonRepository = new JsonHeroRepository(Properties.Settings.Default.HeroFilePath);
			_webApiRepository = new WebApiHeroRepository(Properties.Settings.Default.WebApiUrl);
		}

		private void ApiButton_OnClick(object sender, RoutedEventArgs e)
		{
			LoadHeroList(_webApiRepository, "web service");
		}

		private void JsonButton_OnClick(object sender, RoutedEventArgs e)
		{
			LoadHeroList(_jsonRepository, "json file");
		}

		private void ClearButton_OnClick(object sender, RoutedEventArgs e)
		{
			HeroList.ItemsSource = null;
			StatusBar.Content = "";		}

		private void LoadHeroList(IHeroRepository repository, string source)
		{
			StartLongRunningProcess($"Retrieving from {source}...");

			var worker = new BackgroundWorker();
			worker.DoWork += (obj, args) =>
			{
				args.Result = repository.GetHeroes();
			};

			worker.RunWorkerCompleted += (obj, args) =>
			{
				var heroes = args.Result as List<Hero>;
				ShowResults(heroes, source);
			};

			worker.RunWorkerAsync();
		}
		private void StartLongRunningProcess(string message)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			StatusBar.Content = message;
		}
		private void ShowResults(List<Hero> heroes, string source)
		{
			if (heroes == null)
			{
				HeroList.ItemsSource = new List<Hero>() { new Hero() { HeroName = "Service down..." } };
				StatusBar.Content = $"Could not connect to {source}.";
			}
			else
			{
				HeroList.ItemsSource = heroes;
				StatusBar.Content = $"Success ({source})";
			}

			Mouse.OverrideCursor = null;
		}
	}
}
