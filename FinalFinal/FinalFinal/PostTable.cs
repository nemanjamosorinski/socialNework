//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostTable
    {
        public int IDPost { get; set; }
        public string PostTitle { get; set; }
        public Nullable<int> ImageSize { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        public string TextPost { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
    }
}
