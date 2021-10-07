using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{

    public class payload
    {
        public int id_user { get; set; }
        public string token { get; set; }
        public string timeleft { get; set; }

    }
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string adress { get; set; }
        public 

        override bool Equals(object obj)
        {
            User user = obj as User;
            return id == user.id;
        }
    }
}
