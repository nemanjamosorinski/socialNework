using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplication6.Models
{
    public class UserRegistration
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Morate uneti korisničko ime.")]
        [Display(Name = "Korisničko ime:")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdite lozinku:")]
        [Compare("Password", ErrorMessage = "Lozinke se ne poklapaju!")]
        public string ConfirmPassword { get; set; }


    }

    public class NewPost
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("UserRegistration")]
        public int UserId { get; set; }
        public string PostContent { get; set; }
        public virtual UserRegistration UserRegistration { get; set; }

    }
}