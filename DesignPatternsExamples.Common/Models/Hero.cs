﻿namespace DesignPatternsExamples.Common.Models
{
	public abstract class Hero
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string HeroName { get; set; }
		public ComicType ComicType { get; set; }
	}
}
