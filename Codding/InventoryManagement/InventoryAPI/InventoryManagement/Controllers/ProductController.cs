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
    public class ProductController : ApiController
    {
        #region ProductSelectAll
        //Here Use Store Procedure because of server side pagination ussing Store Procedure 
        public IHttpActionResult Get(int PageNo, int PageSize)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Product_SelectAllPagination";
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
                objCmd.CommandText = "PR_Product_CountProducts";

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
        #endregion ProductSelectAll

        #region Search Product
        public IHttpActionResult Get(int PageNo, int PageSize, string SearchText)
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString);
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Product_SearchByProductName";
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
        #endregion Search Product

        #region GetAll
        [HttpGet]
        [Route("api/product/all")]
        public IHttpActionResult GetProduct()
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var productList = entities.Products.Where(ord => ord.Status == false).ToList();
                    if (productList != null)
                    {
                        return Ok(productList);
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
        public IHttpActionResult GetProductByID(int id)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var product = entities.Products.Where(ord => ord.Status == false).FirstOrDefault(cus => cus.ProductID == id);
                    if (product != null)
                    {
                        return Ok(product);
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

        #region ProductInsert
        [HttpPost]
        public IHttpActionResult PostProduct([FromBody] Product product)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    product.Status = false;
                    product.CreatedDate = DateTime.Now;
                    entities.Products.Add(product);
                    entities.SaveChanges();

                    return Ok("Data Inserted Successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion ProductInsert

        #region ProductUpdate
        [HttpPut]
        public IHttpActionResult PutProduct(int id, [FromBody] Product product)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var pro = entities.Products.Where(ord => ord.Status == false).FirstOrDefault(p => p.ProductID == id);

                    if (pro != null)
                    {
                        pro.ProductName = product.ProductName;
                        pro.Stock = product.Stock;
                        pro.Price = product.Price;
                        pro.UpdatedDate = DateTime.Now;

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
        #endregion ProductUpdate

        #region DeleteProduct
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    var proID = entities.Products.Where(ord => ord.Status == false).FirstOrDefault(p => p.ProductID == id);
                    if (proID != null)
                    {
                        proID.Status = true;
                        //entities.Products.Remove(proID);
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
        #endregion DeleteProduct
    }
}
