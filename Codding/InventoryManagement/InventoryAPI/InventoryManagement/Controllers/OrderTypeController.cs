using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagement.Controllers
{
    public class OrderTypeController : ApiController
    {
        #region GetAll
        [HttpGet]
        public IHttpActionResult GetOrderType()
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var orderTypeList = entities.OrderTypes.Where(ord => ord.Status == false).ToList();
                    if (orderTypeList != null)
                    {
                        return Ok(orderTypeList);
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
        public IHttpActionResult GetOrderTypeByID(int id)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var orderType = entities.OrderTypes.Where(ord => ord.Status == false).FirstOrDefault(ordertype => ordertype.OrderTypeID == id);
                    if (orderType != null)
                    {
                        return Ok(orderType);
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

        #region OrderTypeInsert
        [HttpPost]
        public IHttpActionResult PostOrderType([FromBody] OrderType orderType)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    orderType.Status = false;
                    orderType.CreatedDate = DateTime.Now;
                    entities.OrderTypes.Add(orderType);
                    
                    entities.SaveChanges();

                    return Ok("Data Inserted Successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion OrderTypeInsert

        #region OrderTypeUpdate
        [HttpPut]
        public IHttpActionResult PutOrderType(int id, [FromBody] OrderType orderType)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    entities.Configuration.LazyLoadingEnabled = false;
                    var type = entities.OrderTypes.Where(ord => ord.Status == false).FirstOrDefault(t => t.OrderTypeID == id);

                    if (type != null)
                    {
                        type.OrderTypeName = orderType.OrderTypeName;
                        type.Detail = orderType.Detail;
                        type.UpdatedDate = DateTime.Now;

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
        #endregion OrderTypeUpdate

        #region DeleteOrderType
        [HttpDelete]
        public IHttpActionResult DeleteOrderType(int id)
        {
            try
            {
                using (InventoryDBEntities entities = new InventoryDBEntities())
                {
                    var typeID = entities.OrderTypes.Where(ord => ord.Status == false).FirstOrDefault(t => t.OrderTypeID == id);
                    if (typeID != null)
                    {
                        typeID.Status = true;
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
        #endregion DeleteOrderType
    }
}
