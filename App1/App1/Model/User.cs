using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{
    
    public class Response<T>
    {
        public uint status { get; set; }
        public string statusText { get; set; }
        public T payload  { get; set; }
    }
 
    public class payload
    {
        public string id_user { get; set; }
        public string token { get; set; }
        public string timeleft { get; set; }

    }
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public int createdon { get; set; }
        public string email { get; set; }
        public string surname { get; set; }
        public string middle_name { get; set; }

        public int type_acc { get; set; }
        public int external_id { get; set; }
        //public string password { get; set; }
        public string adress { get; set; }
        public int brith_day { get; set; }
        public int gender { get; set; }
        public int last_active { get; set; }

        public override bool Equals(object obj)
        {
            User user = obj as User;
            return id == user.id;
        }
    }
}
