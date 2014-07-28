using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication10.Models
{
    public class PostContent
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public byte[] Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public string TextPost { get; set; }
    }
}