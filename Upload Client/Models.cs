using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upload_Client
{
    class User
    {
        public string id { get; set; }
        
        public string home_id { get; set; }
        

        public User(JToken obj)
        {
           
            
            id = (string)obj["id"];
            home_id = (string)obj["home_id"];

        }

    }
    class Upload_File
    {
        public string name { get; set; }
        public string parent_id { get; set; }
        public bool resolve { get; set; }
    }


}
