using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApplication2.Areas.HelpPage;
using WebApplication2.Areas.HelpPage.DbStructure;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        /// <summary>
        /// Retrieves the list of values
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<string> Get()
        public string Get()
        {
            String readAll = "";
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                SqlStartupConfig startup = new SqlStartupConfig();
                startup.initialize(builder);
                //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                //builder.DataSource = "theblackswimmers.database.windows.net";
                //builder.UserID = "darklordpaladin";
                //builder.Password = "110943R0salina";
                // builder.InitialCatalog = "songofthevoid";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT title, body ");
                    sb.Append("FROM [dbo].[text];");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                                readAll += (reader.GetString(0) + " " + reader.GetString(1) + "\r\n");
                            }
                        }
                    }
                }
            }

            catch (SqlException e)
            {
                return e.ToString();
            }
            // Console.ReadLine();
            return readAll;
            //return new string[] { "value1", "value2" };
        }

        // GET api/test/5
        /// <summary>
        /// Retrieves one value from the list of values
        /// </summary>
        /// <param name=<em>"id"</em>>The id of the item to be retrieved</param>
        /// <returns></returns>
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET api/getUserInfo
        /// <summary>
        /// Retrieves one value from the list of values
        /// </summary>
        /// <param name=<em>"username"</em>>The username to be retrieved</param>
        /// <returns></returns>
        public Users GetUserInfo(int userid)
        {
            String[] userName = new String[2];
            String readAll = "";
            Users user = new Users();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                SqlStartupConfig startup = new SqlStartupConfig();
                startup.initialize(builder);

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT USER_NAME, USER_WELCOME_SPLASH ");
                    sb.Append("FROM [dbo].[USERS] WHERE USER_ID = " + userid + ";");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                                user.user_name = reader.GetString(0);
                                user.user_welcome_splash = reader.GetString(1);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                user.user_name = "INVALID USER";
                user.user_welcome_splash = "SPLASH NOT FOUND";
                return user;
            }
            return user;
        }

        // POST api/bob
        /// <summary>
        /// Insert a new value in the list
        /// </summary>
        /// <param name=<em>"value"</em>>New value to be inserted</param>
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/yoboy/5
        /// <summary>
        /// Change a single value in the list
        /// </summary>
        /// <param name=<em>"id"</em>>The id of the value to be changed</param>
        /// <param name=<em>"value"</em>>The new value</param>
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/deleteValue
        /// <summary>
        /// Delete an item from the list
        /// </summary>
        /// <param name=<em>"id"</em>>id of the item to be deleted</param>
        //public void Delete(int id)
        //{
        //}
    }
}
