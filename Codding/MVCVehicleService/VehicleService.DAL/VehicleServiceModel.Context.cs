﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VehicleServiceEntities : DbContext
    {
        public VehicleServiceEntities()
            : base("name=VehicleServiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookingSlot> BookingSlot { get; set; }
        public virtual DbSet<ServiceBooking> ServiceBooking { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
    
        public virtual ObjectResult<PR_BookingSlot_SelectDropdownList_Result> PR_BookingSlot_SelectDropdownList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_BookingSlot_SelectDropdownList_Result>("PR_BookingSlot_SelectDropdownList");
        }
    
        public virtual int PR_ServiceBooking_DeleteBYPK(Nullable<int> serviceBookingID)
        {
            var serviceBookingIDParameter = serviceBookingID.HasValue ?
                new ObjectParameter("ServiceBookingID", serviceBookingID) :
                new ObjectParameter("ServiceBookingID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_ServiceBooking_DeleteBYPK", serviceBookingIDParameter);
        }
    
        public virtual int PR_ServiceBooking_Insert(Nullable<int> vehicleID, Nullable<int> bookingSlotID, string customerName, string customerNo, string registrationNo)
        {
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("VehicleID", vehicleID) :
                new ObjectParameter("VehicleID", typeof(int));
    
            var bookingSlotIDParameter = bookingSlotID.HasValue ?
                new ObjectParameter("BookingSlotID", bookingSlotID) :
                new ObjectParameter("BookingSlotID", typeof(int));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var customerNoParameter = customerNo != null ?
                new ObjectParameter("CustomerNo", customerNo) :
                new ObjectParameter("CustomerNo", typeof(string));
    
            var registrationNoParameter = registrationNo != null ?
                new ObjectParameter("RegistrationNo", registrationNo) :
                new ObjectParameter("RegistrationNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_ServiceBooking_Insert", vehicleIDParameter, bookingSlotIDParameter, customerNameParameter, customerNoParameter, registrationNoParameter);
        }
    
        public virtual int PR_ServiceBooking_InsertOnCondition(Nullable<int> vehicleID, Nullable<int> bookingSlotID, string customerName, string customerNo, string registrationNo, ObjectParameter isExist)
        {
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("VehicleID", vehicleID) :
                new ObjectParameter("VehicleID", typeof(int));
    
            var bookingSlotIDParameter = bookingSlotID.HasValue ?
                new ObjectParameter("BookingSlotID", bookingSlotID) :
                new ObjectParameter("BookingSlotID", typeof(int));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var customerNoParameter = customerNo != null ?
                new ObjectParameter("CustomerNo", customerNo) :
                new ObjectParameter("CustomerNo", typeof(string));
    
            var registrationNoParameter = registrationNo != null ?
                new ObjectParameter("RegistrationNo", registrationNo) :
                new ObjectParameter("RegistrationNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_ServiceBooking_InsertOnCondition", vehicleIDParameter, bookingSlotIDParameter, customerNameParameter, customerNoParameter, registrationNoParameter, isExist);
        }
    
        public virtual ObjectResult<PR_ServiceBooking_SelectAll_Result> PR_ServiceBooking_SelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_ServiceBooking_SelectAll_Result>("PR_ServiceBooking_SelectAll");
        }
    
        public virtual ObjectResult<Nullable<int>> PR_ServiceBooking_SelectByCondition(Nullable<int> bookingSlotID)
        {
            var bookingSlotIDParameter = bookingSlotID.HasValue ?
                new ObjectParameter("BookingSlotID", bookingSlotID) :
                new ObjectParameter("BookingSlotID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("PR_ServiceBooking_SelectByCondition", bookingSlotIDParameter);
        }
    
        public virtual ObjectResult<PR_ServiceBooking_SelectByPK_Result> PR_ServiceBooking_SelectByPK(Nullable<int> serviceBookingID)
        {
            var serviceBookingIDParameter = serviceBookingID.HasValue ?
                new ObjectParameter("ServiceBookingID", serviceBookingID) :
                new ObjectParameter("ServiceBookingID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_ServiceBooking_SelectByPK_Result>("PR_ServiceBooking_SelectByPK", serviceBookingIDParameter);
        }
    
        public virtual int PR_ServiceBooking_UpdateByPK(Nullable<int> serviceBookingID, Nullable<int> vehicleID, Nullable<int> bookingSlotID, string customerName, string customerNo, string registrationNo)
        {
            var serviceBookingIDParameter = serviceBookingID.HasValue ?
                new ObjectParameter("ServiceBookingID", serviceBookingID) :
                new ObjectParameter("ServiceBookingID", typeof(int));
    
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("VehicleID", vehicleID) :
                new ObjectParameter("VehicleID", typeof(int));
    
            var bookingSlotIDParameter = bookingSlotID.HasValue ?
                new ObjectParameter("BookingSlotID", bookingSlotID) :
                new ObjectParameter("BookingSlotID", typeof(int));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var customerNoParameter = customerNo != null ?
                new ObjectParameter("CustomerNo", customerNo) :
                new ObjectParameter("CustomerNo", typeof(string));
    
            var registrationNoParameter = registrationNo != null ?
                new ObjectParameter("RegistrationNo", registrationNo) :
                new ObjectParameter("RegistrationNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_ServiceBooking_UpdateByPK", serviceBookingIDParameter, vehicleIDParameter, bookingSlotIDParameter, customerNameParameter, customerNoParameter, registrationNoParameter);
        }
    
        public virtual int PR_Vehicle_DeleteBYPK(Nullable<int> vehicleID)
        {
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("VehicleID", vehicleID) :
                new ObjectParameter("VehicleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_Vehicle_DeleteBYPK", vehicleIDParameter);
        }
    
        public virtual int PR_Vehicle_Insert(string vehicleName)
        {
            var vehicleNameParameter = vehicleName != null ?
                new ObjectParameter("VehicleName", vehicleName) :
                new ObjectParameter("VehicleName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_Vehicle_Insert", vehicleNameParameter);
        }
    
        public virtual ObjectResult<PR_Vehicle_SelectAll_Result> PR_Vehicle_SelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_Vehicle_SelectAll_Result>("PR_Vehicle_SelectAll");
        }
    
        public virtual ObjectResult<PR_Vehicle_SelectByPK_Result> PR_Vehicle_SelectByPK(Nullable<int> vehicleID)
        {
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("VehicleID", vehicleID) :
                new ObjectParameter("VehicleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_Vehicle_SelectByPK_Result>("PR_Vehicle_SelectByPK", vehicleIDParameter);
        }
    
        public virtual ObjectResult<PR_Vehicle_SelectDropdownList_Result> PR_Vehicle_SelectDropdownList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PR_Vehicle_SelectDropdownList_Result>("PR_Vehicle_SelectDropdownList");
        }
    
        public virtual int PR_Vehicle_UpdateByPK(Nullable<int> vehicleID, string vehicleName)
        {
            var vehicleIDParameter = vehicleID.HasValue ?
                new ObjectParameter("VehicleID", vehicleID) :
                new ObjectParameter("VehicleID", typeof(int));
    
            var vehicleNameParameter = vehicleName != null ?
                new ObjectParameter("VehicleName", vehicleName) :
                new ObjectParameter("VehicleName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PR_Vehicle_UpdateByPK", vehicleIDParameter, vehicleNameParameter);
        }
    }
}
