using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication8.Models
{
    public class Class1
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        public string ImageComment { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimoType { get; set; }
    }
}