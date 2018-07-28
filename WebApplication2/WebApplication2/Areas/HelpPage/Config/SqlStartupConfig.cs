using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Data;

namespace WebApplication2.Areas.HelpPage
{
    public class SqlStartupConfig
    {
        public SqlStartupConfig() { }

        public void initialize(SqlConnectionStringBuilder builder)
        {
            builder.DataSource = "theblackswimmers.database.windows.net";
            builder.UserID = "darklordpaladin";
            builder.Password = "110943R0salina";
            builder.InitialCatalog = "songofthevoid";
            //builder.ConnectionString = createConnectionString(builder);
        }


        public String ConnectionString { get; internal set; }

      //  private String createConnectionString(SqlConnectionStringBuilder builder)
      //  {
      //      return (builder.ConnectionString);
      //  }

    }
}