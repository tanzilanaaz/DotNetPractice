//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyShopApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> cat_id { get; set; }
        public Nullable<int> brand_id { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
