//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webNew3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerOrder
    {
        public int CustomerOrderId { get; set; }
        public int BookId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDateTime { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}