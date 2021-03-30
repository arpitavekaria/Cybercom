using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VehicleService.Model
{
    public class ServiceBookingModel
    {
        public int? ServiceBookingID { get; set; }
        public int VehicleID { get; set; }
        public string VehicleName { get; set; }
        public int BookingSlotID { get; set; }
        public string BookingSlotTime { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please Enter Customer No")]
        public string CustomerNo { get; set; }

        [Required(ErrorMessage = "Please Enter Registration No")]
        public string RegistrationNo { get; set; }

    }
}
