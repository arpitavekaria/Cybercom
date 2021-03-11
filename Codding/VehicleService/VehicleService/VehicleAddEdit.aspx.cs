using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace VehicleService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["VehicleID"] != null)
                {
                    #region Load Data in Edit Mode
                    LoadControls(Convert.ToInt32(Request.QueryString["VehicleID"]));
                    lblPageHeader.Text = "Vehicle Edit";
                    #endregion Load Data in Edit Mode
                }
                else
                {
                    lblPageHeader.Text = "Vehicle Add";
                }
            }
        }
        #endregion Load Event

        #region Load Controls
        private void LoadControls(Int32 VehicleID)
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
                        objCmd.CommandText = "PR_Vehicle_SelectByPK";
                        objCmd.Parameters.AddWithValue("@VehicleID", VehicleID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["VehicleName"].Equals(DBNull.Value))
                                {
                                    txtVehicleName.Text = objSDR["VehicleName"].ToString();
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

            #region Local Variables
            SqlString strVehicleName = SqlString.Null;
            #endregion Local Variables

            #region Server Side Validation

            string strError = "";
            if (txtVehicleName.Text.Trim() == "")
                strError += " <span style='color:Red'>Please Enter Vehicle Name</span><br />";

            if (strError.Trim() != "")
            {
                lblMessage.Text = strError;
                return;
            }

            #endregion Server Side Validation

            #region Read Data
            if (txtVehicleName.Text.Trim() != "")
                strVehicleName = txtVehicleName.Text.Trim();

            #endregion Read Data

            using (SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@VehicleName", txtVehicleName.Text);

                        if (Request.QueryString["VehicleID"] == null)
                        {
                            objCmd.CommandText = "PR_Vehicle_Insert";
                        }
                        else
                        {
                            objCmd.CommandText = "PR_Vehicle_UpdateByPK";
                            objCmd.Parameters.AddWithValue("@VehicleID", Request.QueryString["VehicleID"].ToString());
                        }
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message.ToString();
                    }
                    finally
                    {
                        if (Request.QueryString["VehicleID"] == null)
                        {
                            lblMessage.Text = "Data Inserted Successfully.....";
                            txtVehicleName.Text = "";
                            txtVehicleName.Focus();
                        }
                        else
                        {
                            Response.Redirect("~/VehicleList.aspx");
                        }

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Button : Save

    }
}