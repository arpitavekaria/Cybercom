using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleService.Model;
using VehicleService.DAL;
using BookingSlotService.DAL;

namespace MVCVehicleService.Controllers
{
    public class ServiceBookingController : Controller
    {
        ServiceBookingDAL dalServiceBooking = new ServiceBookingDAL();

        #region Create and Update
        public ActionResult Create(int? id)
        {
            ViewBag.VehicleList = new SelectList(VehicleList(), "VehicleID", "VehicleName");
            ViewBag.BookingSlotList = new SelectList(BookingSlotList(), "BookingSlotID", "BookingSlotTime");
            if (id != null)
            {
                ViewBag.PageTitle = "Update Record";
                ViewBag.Title = ViewBag.Button = "Update";
                var ServiceBooking = dalServiceBooking.SelectByPK(Convert.ToInt32(id));
                return View(ServiceBooking);
            }
            else
            {
                ViewBag.PageTitle = "Add New Record";
                ViewBag.Title = "Add New";
                ViewBag.Button = "Save";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(ServiceBookingModel serviceBookingModel)
        {
            if (ModelState.IsValid)
            {
                if (serviceBookingModel.ServiceBookingID != null)
                {
                    dalServiceBooking.Update(serviceBookingModel);
                    return RedirectToAction("ServiceBookingList");
                }
                else
                {
                    dalServiceBooking.Insert(serviceBookingModel);
                    ViewBag.InsertMessage = "Data Inserted Successfully...";
                }
                ModelState.Clear();
            }
            return View("Create");
        }

        public List<VehicleModel> VehicleList()
        {
            VehicleDAL dalVehicle = new VehicleDAL();
            List<VehicleModel> vehicleList = dalVehicle.SelectVehicleDropDownList();
            return vehicleList;
        }
        public List<BookingSlotModel> BookingSlotList()
        {
            BookingSlotDAL dalBookingSlot = new BookingSlotDAL();
            List<BookingSlotModel> bookingSlotList = dalBookingSlot.SelectBookingSlotDropDownList();
            return bookingSlotList;
        }
        #endregion Create and Update

        #region ServiceBookingList
        public ActionResult ServiceBookingList()
        {
            List<ServiceBookingModel> serviceBookingList = dalServiceBooking.SelectAll();
            ViewData["ServiceBooking"] = serviceBookingList;
            return View();
        }
        #endregion ServiceBookingList

        #region Delete
        public ActionResult Delete(int id)
        {
            dalServiceBooking.Delete(id);
            return RedirectToAction("ServiceBookingList");
        }
        #endregion Delete
    }
}