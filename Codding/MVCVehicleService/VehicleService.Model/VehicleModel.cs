using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VehicleService.Model
{
    public class VehicleModel
    {
        public int? VehicleID { get; set; }

        [Required(ErrorMessage = "Please Enter Vehicle Name")]
        public string VehicleName { get; set; }
    }
}
