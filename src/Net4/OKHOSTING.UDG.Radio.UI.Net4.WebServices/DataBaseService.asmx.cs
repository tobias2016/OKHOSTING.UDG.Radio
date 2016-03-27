using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace OKHOSTING.Sql.Net4.Web.Services
{
	/// <summary>
	/// Acts as a proxy between a native DataBase and the world, so you can use it from mobile devices or incompatibole platforms
	/// </summary>
	[WebService(Namespace = "http://okhosting.com/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.Web.Script.Services.ScriptService]
	public class DataBaseService : System.Web.Services.WebService
	{
		/// <summary>
		/// The real DataBase working behind the scene
		/// </summary>
		protected readonly Sql.Net4.DataBase DataBase;

		public DataBaseService()
		{
			Sql.Net4.DataBase.Setup += DataBase_Setup;
			DataBase = (Sql.Net4.DataBase) Sql.Net4.DataBase.CreateDataBase();
		}

		/// <summary>
		/// Modify this method to actually return  the kind of DataBase you need
		/// </summary>
		/// <returns>A </returns>
		private Sql.DataBase DataBase_Setup()
		{
			//modify this to return the right database you wish to use
			OKHOSTING.Core.Net4.AppConfig config = new Core.Net4.AppConfig();
			string connectionString = (string) config.GetValue("connectionString", typeof(string));
			return new MySql.DataBase() { ConnectionString = connectionString };
		}

		[WebMethod]
		public int Execute(Command command)
		{
			return DataBase.Execute(command);
		}

		[WebMethod]
		public SelectResult Select(Command command)
		{
			IDataTable table = DataBase.GetDataTable(command);
			SelectResult result = new SelectResult();
			int columnCount = table.Schema.Count();
			result.ColumnNames = new string[columnCount];
			result.ColumnTypes = new string[columnCount];

			for (int row = 0; row < table.Count; row++)
			{
				result.Rows[row] = new string[columnCount];

				for (int column = 0; column < table.Schema.Count(); column++)
				{
					result.Rows[row][column] = OKHOSTING.Data.Convert.ChangeType<string>(table[row][column]);
				}
			}

			return result;
		}
	}
}
