using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Model;
using VehicleService.DAL;

namespace BookingSlotService.DAL
{
    public class BookingSlotDAL : DatabaseConfig
    {
        #region Local Veriable
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local Veriable

        #region BookingSlotDropDown
        public List<BookingSlotModel> SelectBookingSlotDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_BookingSlot_SelectDropDownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<BookingSlotModel> listBookingSlot = new List<BookingSlotModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //dt.Load(objSDR);
                            while (objSDR.Read())
                            {
                                BookingSlotModel BookingSlotModel = new BookingSlotModel();
                                if (!objSDR["BookingSlotID"].Equals(DBNull.Value))
                                {
                                    BookingSlotModel.BookingSlotID = Convert.ToInt32(objSDR["BookingSlotID"]);
                                }
                                if (!objSDR["BookingSlotTime"].Equals(DBNull.Value))
                                {
                                    BookingSlotModel.BookingSlotTime = Convert.ToString(objSDR["BookingSlotTime"]);
                                }
                                listBookingSlot.Add(BookingSlotModel);
                            }
                            return listBookingSlot;
                        }
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion BookingSlotDropDown
    }
}
