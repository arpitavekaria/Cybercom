using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehicleService
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDownList();
                if (Request.QueryString["ServiceBookingID"] != null)
                {
                    #region Load Data in Edit Mode
                    LoadControls(Convert.ToInt32(Request.QueryString["ServiceBookingID"]));
                    lblPageHeader.Text = "Service Booking Edit";
                    #endregion Load Data in Edit Mode
                }
                else
                {
                    lblPageHeader.Text = "Service Booking Add";
                }
            }
        }

        #region Filldropdown
        private void FillDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Vehicle_SelectDropdownList";
                        #endregion Prepare Command

                        SqlDataReader objSDRVehicle = objCmd.ExecuteReader();
                        ddlVehicle.DataSource = objSDRVehicle;
                        ddlVehicle.DataTextField = "VehicleName";
                        ddlVehicle.DataValueField = "VehicleID";
                        ddlVehicle.DataBind();

                        objSDRVehicle.Close();

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_BookingSlot_SelectDropdownList";
                        #endregion Prepare Command

                        SqlDataReader objSDRBookingSlot = objCmd.ExecuteReader();
                        ddlBookingSlot.DataSource = objSDRBookingSlot;
                        ddlBookingSlot.DataTextField = "BookingSlotTime";
                        ddlBookingSlot.DataValueField = "BookingSlotID";
                        ddlBookingSlot.DataBind();

                        objSDRBookingSlot.Close();

                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message.ToString();
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Filldropdown

        #region Load Controls
        private void LoadControls(Int32 ServiceBookingID)
        {
            using (SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ServiceBooking_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ServiceBookingID", ServiceBookingID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                
                                if (!objSDR["VehicleID"].Equals(DBNull.Value))
                                {
                                    ddlVehicle.SelectedValue = objSDR["VehicleID"].ToString();
                                }
                                if (!objSDR["BookingSlotID"].Equals(DBNull.Value))
                                {
                                    ddlBookingSlot.SelectedValue = objSDR["BookingSlotID"].ToString();
                                }
                                if (!objSDR["CustomerName"].Equals(DBNull.Value))
                                {
                                    txtCustomerName.Text = objSDR["CustomerName"].ToString();
                                }
                                if (!objSDR["CustomerNo"].Equals(DBNull.Value))
                                {
                                    txtCustomerNo.Text = objSDR["CustomerNo"].ToString();
                                }
                                if (!objSDR["RegistrationNo"].Equals(DBNull.Value))
                                {
                                    txtRegistrationNo.Text = objSDR["RegistrationNo"].ToString();
                                }
                            }
                        }

                        #endregion ReadData and Set Controls
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message.ToString();
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Load Controls

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {


            #region Server Side Validation

            string strError = "";
            if (txtCustomerName.Text.Trim() == "")
                strError += " <span style='color:Red'>Enter Customer Name</span><br />";

            if (txtCustomerNo.Text.Trim() == "")
                strError += " <span style='color:Red'>Enter Customer No</span><br />";

            if (txtRegistrationNo.Text.Trim() == "")
                strError += " <span style='color:Red'>Enter Registration No</span><br />";

            if (ddlVehicle.SelectedValue == "-1")
                strError += " <span style='color:Red'>Select Vehicle</span><br />";

            if (ddlBookingSlot.SelectedValue == "-1")
                strError += " <span style='color:Red'>Select Booking Slot</span><br />";

            if (strError.Trim() != "")
            {
                lblMessage.Text = strError;
                return;
            }

            #endregion Server Side Validation



            using (SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@VehicleID", ddlVehicle.SelectedValue);
                        objCmd.Parameters.AddWithValue("@BookingSlotID", ddlBookingSlot.SelectedValue);
                        objCmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim());
                        objCmd.Parameters.AddWithValue("@CustomerNo", txtCustomerNo.Text.Trim());
                        objCmd.Parameters.AddWithValue("@RegistrationNo", txtRegistrationNo.Text.Trim());


                        if (Request.QueryString["ServiceBookingID"] == null)
                        {
                            objCmd.CommandText = "PR_ServiceBooking_InsertOnCondition";
                            SqlParameter outputPara = new SqlParameter();
                            outputPara.ParameterName = "@isExist";
                            outputPara.Direction = System.Data.ParameterDirection.Output;
                            outputPara.SqlDbType = System.Data.SqlDbType.Bit;
                            objCmd.Parameters.Add(outputPara);
                            objCmd.ExecuteNonQuery();
                            string outValue = outputPara.Value.ToString();
                            if (outValue == "1")
                            {
                                lblMessage.Text = "Data Inserted Successfully.....";
                            }
                            else
                            {
                                lblMessage.Text = "Record already Exists";
                            }
                        }
                        else
                        {
                            objCmd.CommandText = "PR_ServiceBooking_UpdateByPK";
                            objCmd.Parameters.AddWithValue("@ServiceBookingID", Request.QueryString["ServiceBookingID"].ToString());
                            objCmd.ExecuteNonQuery();
                            lblMessage.Text = "Data Updated Successfully.....";
                        }
                        #endregion Prepare Command
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message.ToString();
                    }
                    finally
                    {
                        if (Request.QueryString["ServiceBookingID"] == null)
                        {
                            txtCustomerName.Text = "";
                            txtCustomerNo.Text = "";
                            txtRegistrationNo.Text = "";
                            txtCustomerName.Focus();
                        }
                        else
                        {
                            Response.Redirect("~/ServiceBookingList.aspx");
                        }

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Button : Save

        //protected void ddlBookingSlot_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    using (SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString))
        //    {
        //        objConn.Open();
        //        SqlCommand command = new SqlCommand("Select BookingSlotID from ServiceBooking", objConn);
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                foreach (ListItem item in ddlBookingSlot.Items)
        //                {
                           
        //                }
        //            }
        //        }
        //    }
        //}
    }
}