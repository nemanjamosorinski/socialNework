using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication5.Models
{
    public class User
    {
            [Key]
            public int ID { get; set; }

            [Required(ErrorMessage = "You must enter validy user name.")]
            [Display(Name = "User name:")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password:")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password:")]
            [Compare("Password", ErrorMessage = "Passwords are not equal!")]
            public string ConfirmPassword { get; set; }
        }

        public class UserDBContext : DbContext
        {
            public DbSet<User> Users { get; set; }
        }
}
