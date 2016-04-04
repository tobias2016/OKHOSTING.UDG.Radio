using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UDG.Radio
{
	/// <summary>
	/// An episode in a show
	/// </summary>
	public class Episode
	{
		public Show Show { get; set; }
		public DateTime PublishedOn { get; set; }
		public string Name { get; set; }
		public Uri EpisodeUri { get; set; }
	}
}
