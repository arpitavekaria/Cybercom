//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagement
{
    using System;
    
    public partial class PR_Orders_SelectAllByDate_Result
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string OrderTypeName { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
