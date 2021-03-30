using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Model;

namespace VehicleService.DAL
{
    public class ServiceBookingDAL : DatabaseConfig
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

        #region Insert Operaction
        public Boolean Insert(ServiceBookingModel serviceBooking)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ServiceBooking_InsertOnCondition";
                        objCmd.Parameters.AddWithValue("@VehicleID", serviceBooking.VehicleID);
                        objCmd.Parameters.AddWithValue("@BookingSlotID", serviceBooking.BookingSlotID);
                        objCmd.Parameters.AddWithValue("@CustomerName", serviceBooking.CustomerName);
                        objCmd.Parameters.AddWithValue("@CustomerNo", serviceBooking.CustomerNo);
                        objCmd.Parameters.AddWithValue("@RegistrationNo", serviceBooking.RegistrationNo);
                        //SqlParameter outputPara = new SqlParameter();
                        //outputPara.ParameterName = "@isExist";
                        //outputPara.Direction = System.Data.ParameterDirection.Output;
                        //outputPara.SqlDbType = System.Data.SqlDbType.Bit;
                        //var outpra = objCmd.Parameters.Add(outputPara);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion Insert Operaction

        #region SelectAll
        public List<ServiceBookingModel> SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ServiceBooking_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<ServiceBookingModel> listServiceBooking = new List<ServiceBookingModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                ServiceBookingModel serviceBookingModel = new ServiceBookingModel();
                                if (!objSDR["ServiceBookingID"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.ServiceBookingID = Convert.ToInt32(objSDR["ServiceBookingID"]);
                                }
                                if (!objSDR["VehicleID"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.VehicleID = Convert.ToInt32(objSDR["VehicleID"]);
                                }
                                if (!objSDR["BookingSlotID"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.BookingSlotID = Convert.ToInt32(objSDR["BookingSlotID"]);
                                }
                                if (!objSDR["BookingSlotTime"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.BookingSlotTime = Convert.ToString(objSDR["BookingSlotTime"]);
                                }
                                if (!objSDR["CustomerName"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.CustomerName = Convert.ToString(objSDR["CustomerName"]);
                                }
                                if (!objSDR["CustomerNo"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.CustomerNo = Convert.ToString(objSDR["CustomerNo"]);
                                }
                                if (!objSDR["RegistrationNo"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.RegistrationNo = Convert.ToString(objSDR["RegistrationNo"]);
                                }
                                listServiceBooking.Add(serviceBookingModel);
                            }
                        }
                        #endregion ReadData and Set Controls

                        return listServiceBooking;
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
        #endregion SelectAll

        #region SelectByPK
        public ServiceBookingModel SelectByPK(SqlInt32 ServiceBookingID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command
                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_ServiceBooking_SelectByPK";
                        objcmd.Parameters.AddWithValue("@ServiceBookingID", ServiceBookingID);
                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        ServiceBookingModel serviceBookingModel = new ServiceBookingModel();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ServiceBookingID"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.ServiceBookingID = Convert.ToInt32(objSDR["ServiceBookingID"]);
                                }
                                if (!objSDR["VehicleID"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.VehicleID = Convert.ToInt32(objSDR["VehicleID"]);
                                }
                                if (!objSDR["BookingSlotID"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.BookingSlotID = Convert.ToInt32(objSDR["BookingSlotID"]);
                                }
                                if (!objSDR["BookingSlotTime"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.BookingSlotTime = Convert.ToString(objSDR["BookingSlotTime"]);
                                }
                                if (!objSDR["CustomerName"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.CustomerName = Convert.ToString(objSDR["CustomerName"]);
                                }
                                if (!objSDR["CustomerNo"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.CustomerNo = Convert.ToString(objSDR["CustomerNo"]);
                                }
                                if (!objSDR["RegistrationNo"].Equals(DBNull.Value))
                                {
                                    serviceBookingModel.RegistrationNo = Convert.ToString(objSDR["RegistrationNo"]);
                                }
                            }
                        }
                        return serviceBookingModel;
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
        #endregion SelectByPK

        #region Update

        public Boolean Update(ServiceBookingModel serviceBooking)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ServiceBooking_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@ServiceBookingID", serviceBooking.ServiceBookingID);
                        objCmd.Parameters.AddWithValue("@VehicleID", serviceBooking.VehicleID);
                        objCmd.Parameters.AddWithValue("@BookingSlotID", serviceBooking.BookingSlotID);
                        objCmd.Parameters.AddWithValue("@CustomerName", serviceBooking.CustomerName);
                        objCmd.Parameters.AddWithValue("@CustomerNo", serviceBooking.CustomerNo);
                        objCmd.Parameters.AddWithValue("@RegistrationNo", serviceBooking.RegistrationNo);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }

        #endregion Update

        #region Delete 

        public Boolean Delete(SqlInt32 ServiceBookingID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ServiceBooking_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ServiceBookingID", ServiceBookingID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }

        #endregion Delete
    }
}
