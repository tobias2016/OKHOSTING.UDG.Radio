using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UDG.Radio
{
	/// <summary>
	/// A TV or Radio station
	/// </summary>
	public class Station
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string WebSiteUri { get; set; }
		public string StramingUri { get; set; }
	}
}
