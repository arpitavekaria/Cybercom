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

namespace VehicleService.DAL
{
    public class VehicleDAL : DatabaseConfig
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

        public Boolean Insert(VehicleModel vehicleModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Vehicle_Insert";
                        objCmd.Parameters.AddWithValue("@VehicleName", vehicleModel.VehicleName);
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
        public List<VehicleModel> SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Vehicle_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and Set Controls

                        List<VehicleModel> listVehicle = new List<VehicleModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //dt.Load(objSDR);
                            while (objSDR.Read())
                            {
                                VehicleModel entVehicle = new VehicleModel();
                                if (!objSDR["VehicleID"].Equals(DBNull.Value))
                                {
                                    entVehicle.VehicleID = Convert.ToInt32(objSDR["VehicleID"]);
                                }
                                if (!objSDR["VehicleName"].Equals(DBNull.Value))
                                {
                                    entVehicle.VehicleName = Convert.ToString(objSDR["VehicleName"]);
                                }
                                listVehicle.Add(entVehicle);
                            }
                        }
                        #endregion ReadData and Set Controls

                        return listVehicle;
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
        public VehicleModel SelectByPK(SqlInt32 VehicleID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_Vehicle_SelectByPK";
                        objcmd.Parameters.AddWithValue("@VehicleID", VehicleID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        VehicleModel entVehicle = new VehicleModel();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["VehicleID"].Equals(DBNull.Value))
                                {
                                    entVehicle.VehicleID = Convert.ToInt32(objSDR["VehicleID"]);
                                }
                                if (!objSDR["VehicleName"].Equals(DBNull.Value))
                                {
                                    entVehicle.VehicleName = Convert.ToString(objSDR["VehicleName"]);
                                }
                            }
                        }
                        return entVehicle;
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

        public Boolean Update(VehicleModel vehicleModel)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Vehicle_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@VehicleID", vehicleModel.VehicleID);
                        objCmd.Parameters.AddWithValue("@VehicleName", vehicleModel.VehicleName);
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

        public Boolean Delete(SqlInt32 VehicleID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Vehicle_DeleteBYPK";
                        objCmd.Parameters.AddWithValue("@VehicleID", VehicleID);
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

        #region VehicleDropDown
        public List<VehicleModel> SelectVehicleDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Vehicle_SelectDropDownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        List<VehicleModel> listVehicle = new List<VehicleModel>();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //dt.Load(objSDR);
                            while (objSDR.Read())
                            {
                                VehicleModel vehicleModel = new VehicleModel();
                                if (!objSDR["VehicleID"].Equals(DBNull.Value))
                                {
                                    vehicleModel.VehicleID = Convert.ToInt32(objSDR["VehicleID"]);
                                }
                                if (!objSDR["VehicleName"].Equals(DBNull.Value))
                                {
                                    vehicleModel.VehicleName = Convert.ToString(objSDR["VehicleName"]);
                                }
                                listVehicle.Add(vehicleModel);
                            }
                            return listVehicle;
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
        #endregion VehicleDropDown
    }
}
