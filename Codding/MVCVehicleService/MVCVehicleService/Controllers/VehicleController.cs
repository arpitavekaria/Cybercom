using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleService.Model;
using VehicleService.DAL;

namespace MVCVehicleService.Controllers
{
    public class VehicleController : Controller
    {
        VehicleDAL dalVehicle = new VehicleDAL();

        #region Create and Update
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.PageTitle = "Update Record";
                ViewBag.Title = ViewBag.Button = "Update";
                var Vehicle = dalVehicle.SelectByPK(Convert.ToInt32(id));
                return View(Vehicle);
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
        public ActionResult Create(VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                if (vehicleModel.VehicleID != null)
                {
                    dalVehicle.Update(vehicleModel);
                    return RedirectToAction("VehicleList");
                }
                else
                {
                    dalVehicle.Insert(vehicleModel);
                    ViewBag.InsertMessage = "Data Inserted Successfully...";
                }
                ModelState.Clear();
                return View();
            }
            return View("Create");
        }
        #endregion Create and Update

        #region VehicleList
        public ActionResult VehicleList()
        {
            List<VehicleModel> vehicle = dalVehicle.SelectAll();
            ViewData["Vehicle"] = vehicle;
            return View();
        }
        #endregion VehicleList

        #region Delete
        public ActionResult Delete(int id)
        {
            dalVehicle.Delete(id);
            return RedirectToAction("VehicleList");
        }
        #endregion Delete
    }
}