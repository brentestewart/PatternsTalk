using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DesignPatternsExamples.Common.Factories;
using DesignPatternsExamples.Common.Repositories;

namespace DesignPatternsExamples.HeroApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			// Setup our Repository Factory
			var webApiUrl = DesignPatternsExamples.HeroApp.Properties.Settings.Default.WebApiUrl;
			var jsonFilePath = DesignPatternsExamples.HeroApp.Properties.Settings.Default.HeroFilePath;
			HeroFactory.AddRepository(RepositoryType.DC, new DCHeroRepository(webApiUrl));
			HeroFactory.AddRepository(RepositoryType.Marvel, new MarvelHeroRepository(jsonFilePath));
		}
	}
}
