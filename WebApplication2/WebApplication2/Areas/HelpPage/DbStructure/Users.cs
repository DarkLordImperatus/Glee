using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Areas.HelpPage.DbStructure
{

    public class Users
    {
        public Users()
        {
            int user_id;
            String user_name;
            String user_password;
            String user_welcome_splash;
        }
        
        public int user_id { get; set; }
        public String user_name { get; set; }
        public String user_password { get; set; }
        public String user_welcome_splash { get; set; }
    }

}