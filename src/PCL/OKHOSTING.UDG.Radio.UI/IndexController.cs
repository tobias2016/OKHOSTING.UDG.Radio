using System;
using System.Collections.Generic;
using OKHOSTING.UI;
using OKHOSTING.ORM;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Streaming;

namespace OKHOSTING.UDG.Radio.UI
{ 
    public class IndexController : OKHOSTING.UI.Controller
    {
		/// <summary>
        /// Setups the database
        /// </summary>
        public override void Start()
        {
			base.Start();
            OKHOSTING.ORM.DataBase.Setup += DataBase_Setup;
            DataType dtype = DataType.DefaultMap(typeof(Station));

            //using (var db = DataBase.CreateDataBase())
            //{
            //    if (!db.NativeDataBase.ExistsTable(dtype.Table.Name))
            //    {
            //        db.Create(dtype);
            //    }

            //    var stations = db.Select<Station>();
            //}

            Finish();

            new SplashScreenScontroller().Start();
        }

        private static ORM.DataBase DataBase_Setup()
        {
            return new ORM.DataBase(new Sql.Web.Services.Client.DataBase() { ConnectionString = "http://radioudg.okhosting.com/databaseservice.asmx" }, new Sql.MySql.SqlGenerator());
        }
    }
}