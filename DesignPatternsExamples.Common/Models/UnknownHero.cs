using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsExamples.Common.Models
{
	public class UnknownHero : Hero
	{
		public UnknownHero()
		{
			ComicType = ComicType.Unknown;
		}
	}
}
