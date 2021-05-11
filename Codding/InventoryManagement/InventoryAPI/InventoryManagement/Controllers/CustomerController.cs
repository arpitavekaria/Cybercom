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
    public class CustomerController : ApiController
    {
        #region CustomerSelectAll
        //Here Use Store Procedure because of server side pagination ussing Store Procedure 
        public IHttpActionResult Get(int PageNo, int PageSize)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Customer_SelectAllPagination";
                objCmd.Parameters.AddWithValue("@PageNo", PageNo);
                objCmd.Parameters.AddWithValue("@PageSize", PageSize);

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
                    string message = "No have any Data";
                    return Ok(message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        //Count Total Records
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                int TotalRecords = 0;
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Customer_CountCustomers";

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
        #endregion CustomerSelectAll

        #region Search Customer
        public IHttpActionResult Get(int PageNo, int PageSize, string SearchText)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Customer_SearchByCustomerName";
                objCmd.Parameters.AddWithValue("@PageNo", PageNo);
                objCmd.Parameters.AddWithValue("@PageSize", PageSize);
                objCmd.Parameters.AddWithValue("@SearchText", SearchText);

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
                    string message = "No have any Data";
                    return Ok(message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion Search Customer

        #region GetAll
        [HttpGet]
        [Route("api/customer/all")]
        public IHttpActionResult GetCustomer()
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var customerList = entities.Customers.Where(cus => cus.Status == false).ToList();
                    if (customerList != null)
                    {
                        return Ok(customerList);
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
        #endregion GetAll

        #region GetByID
        [HttpGet]
        public IHttpActionResult GetCustomerByID(int id)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var customer = entities.Customers.Where(cus => cus.Status == false).FirstOrDefault(cus => cus.CustomerID == id);
                    if (customer != null)
                    {
                        return Ok(customer);
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

        #region CustomerInsert
        [HttpPost]
        public IHttpActionResult PostCustomer([FromBody] Customer customer)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    customer.Status = false;
                    customer.CreatedDate = DateTime.Now;
                    entities.Customers.Add(customer);
                    entities.SaveChanges();

                    return Ok("Data Inserted Successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion CustomerInsert

        #region CustomerUpdate
        [HttpPut]
        public IHttpActionResult PutCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var cus = entities.Customers.Where(cust => cust.Status == false).FirstOrDefault(c => c.CustomerID == id);

                    if (cus != null)
                    {
                        cus.CustomerName = customer.CustomerName;
                        cus.Email = customer.Email;
                        cus.Phone = customer.Phone;
                        cus.UpdatedDate = DateTime.Now;

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
        #endregion CustomerUpdate

        #region DeleteCustomer
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    var cusID = entities.Customers.Where(cus => cus.Status == false).FirstOrDefault(e => e.CustomerID == id);
                    if (cusID != null)
                    {
                        cusID.Status = true;
                        //entities.Customers.Remove(cusID);
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
        #endregion DeleteCustomer

      
    }
}
