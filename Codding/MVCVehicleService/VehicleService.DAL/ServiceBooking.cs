//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleService.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceBooking
    {
        public int ServiceBookingID { get; set; }
        public Nullable<int> VehicleID { get; set; }
        public Nullable<int> BookingSlotID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNo { get; set; }
        public string RegistrationNo { get; set; }
    
        public virtual BookingSlot BookingSlot { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
