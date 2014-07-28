using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class NewUser
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserInfo
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class UserStuff
    {
        public string UserPost { get; set; }
    }
}