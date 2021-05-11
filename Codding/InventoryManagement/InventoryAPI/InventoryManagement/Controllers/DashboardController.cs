using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagement.Controllers
{
    public class DashboardController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    var NoOfProduct = entities.Products.Where(pro => pro.Status == false && pro.Stock > 0).Count();
                    var TodayOrder = entities.Orders.Where(ord => ord.OrderDate == DateTime.Today).Count();
                    var LessQuntity = entities.Products.Where(pro => pro.Stock <= 10).Count();

                    string DashbordJsonData = @"{'NoOfProduct':'" + NoOfProduct + "', 'TodayOrder': '" + TodayOrder + "', 'LessQuantity': '" + LessQuntity + "'}";
                    JObject json = JObject.Parse(DashbordJsonData);
                    return Ok(json);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
