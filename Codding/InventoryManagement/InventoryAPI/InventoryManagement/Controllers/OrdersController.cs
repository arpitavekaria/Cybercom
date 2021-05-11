using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagement.Controllers
{
    public class OrdersController : ApiController
    {
        #region OrdersSelectAll
        public IHttpActionResult Get(int PageNo, int PageSize, string Dir)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Orders_SelectAllPagination";
                objCmd.Parameters.AddWithValue("@PageNo", PageNo);
                objCmd.Parameters.AddWithValue("@PageSize", PageSize);
                objCmd.Parameters.AddWithValue("@Direction", Dir);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Ok("No have any Data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //Count Total Records
        public IHttpActionResult Get()
        {
            try
            {
                int TotalRecords = 0;
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Orders_CountOrders";

                using (SqlDataReader objSDR = objCmd.ExecuteReader())
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["TotalRecord"].Equals(DBNull.Value))
                        {
                            TotalRecords = Convert.ToInt32(objSDR["TotalRecord"]);
                        }
                    }
                }

                if (TotalRecords > 0)
                {
                    return Ok(TotalRecords);
                }
                else
                {
                    return Ok("No have any Data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion OrdersSelectAll
        #region GetAll
        [HttpGet]
        [Route("api/orders/all")]
        public IHttpActionResult GetAll()
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Orders_SelectAll";
                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Ok("No have any Data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        //public IHttpActionResult GetOrders()
        //{
        //    try
        //    {
        //        using (InventoryDBEntities entities = new InventoryDBEntities())
        //        {
        //            var ordersList = entities.Orders.Include("OrderType").Include("Customer").Include("Product")
        //                .Where(ord => ord.Status == false && ord.CustomerID == ord.Customer.CustomerID && ord.ProductID == ord.Product.ProductID
        //                        && ord.OrderTypeID == ord.OrderType.OrderTypeID).ToList();
        //            if (ordersList != null)
        //            {
        //                return Ok(ordersList);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}
        #endregion GetAll

        #region GetByID
        [HttpGet]
        public IHttpActionResult GetOrdersByID(int id)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    var orders = entities.Orders.Where(ord => ord.Status == false).FirstOrDefault(e => e.OrderID == id);
                    if (orders != null)
                    {
                        return Ok(orders);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion GetByID

        #region GetByDate
        [HttpPost]
        public IHttpActionResult SearchByDate([FromBody] DateFilterModel dateFilter)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Orders_SelectAllByDate";
                objCmd.Parameters.AddWithValue("@FromDate", dateFilter.FromDate.ToString("dd/MM/yyyy"));
                objCmd.Parameters.AddWithValue("@ToDate", dateFilter.ToDate.ToString("dd/MM/yyyy"));

                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Ok("No have any Data");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion GetByDate

        #region OrderInsert
        //[HttpPost]
        //public IHttpActionResult PostOrders([FromBody] Order order)
        //{
        //    try
        //    {
        //        using (InventoryDBEntities entities = new InventoryDBEntities())
        //        {
        //            order.OrderDate = DateTime.Now;
        //            order.Status = false;
        //            order.CreatedDate = DateTime.Now;
        //            entities.Orders.Add(order);
        //            entities.SaveChanges();

        //            return Ok("Data Inserted Successfully");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}
        #endregion OrderInsert

        #region OrderUpdate
        [HttpPut]
        public IHttpActionResult PutOrder(int id, [FromBody] Order order)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    var ord = entities.Orders.Where(orde => orde.Status == false).FirstOrDefault(e => e.OrderID == id);

                    if (ord != null)
                    {
                        ord.OrderTypeID = order.OrderTypeID;
                        ord.OrderDate = order.OrderDate;
                        ord.CustomerID = order.CustomerID;
                        ord.ProductID = order.ProductID;
                        ord.Quantity = order.Quantity;
                        ord.TotalPrice = order.TotalPrice;
                        ord.UpdatedDate = DateTime.Now;

                        entities.SaveChanges();

                        return Ok("Data Updated Successfully");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion OrderUpdate

        #region DeleteOrder
        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    var ordID = entities.Orders.Where(ord => ord.Status == false).FirstOrDefault(e => e.OrderID == id);
                    if (ordID != null)
                    {
                        ordID.Status = true;
                        //entities.Orders.Remove(ordID);
                        entities.SaveChanges();
                        return Ok("Data Deleted");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion DeleteOrder
    }
}
