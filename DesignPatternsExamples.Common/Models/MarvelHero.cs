using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsExamples.Common.Models
{
	public class MarvelHero : Hero
	{
		public MarvelHero()
		{
			ComicType = ComicType.Marvel;
		}
	}
}
