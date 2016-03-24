using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UDG.Radio
{
	/// <summary>
	/// A TV or radio show
	/// </summary>
	public class Show
	{
		public int Id { get; set; }
		public Station Station { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Uri WebSiteUri { get; set; }
		public Uri StramingUri { get; set; }
	}
}
