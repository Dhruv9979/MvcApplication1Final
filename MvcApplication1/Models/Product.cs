//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1.Models
{
    using System;
    using System.Collections.Generic;
using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;
    public partial class Product
    {
        public int ProductID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Details { get; set; }
        
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<int> Price { get; set; }
        public string ImagePath { get; set; }

        public SelectList CategoryList { get; set; }


        public int Quantity { get; set; }
    }
}
