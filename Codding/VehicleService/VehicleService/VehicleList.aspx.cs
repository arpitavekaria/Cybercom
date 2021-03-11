using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehicleService
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillVehicleGridView();
            }
        }
        #endregion Load Event

        #region GridView

        #region FillGridView
        private void FillVehicleGridView()
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
                        objCmd.CommandText = "PR_Vehicle_SelectAll";
                        #endregion Prepare Command

                        SqlDataReader objSDR = objCmd.ExecuteReader();
                        DataTable dtVehicle = new DataTable();
                        dtVehicle.Load(objSDR);

                        gvVehicle.DataSource = dtVehicle;
                        gvVehicle.DataBind();
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
        #endregion FillGridView

        #region Grid Row Command
        protected void gvVehicle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                DeleteVehicle(Convert.ToInt32(e.CommandArgument));
                FillVehicleGridView();
            }
            #endregion Delete Record
        }
        #endregion Grid Row Command

        #endregion GridView

        #region Function - Delete 
        private void DeleteVehicle(Int32 VehicleID)
        {
            //SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString);
            try
            {
                objConnection.Open();

                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConnection;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Vehicle_DeleteByPK";
                objCmd.Parameters.AddWithValue("@VehicleID", VehicleID);

                objCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if (objConnection.State == ConnectionState.Open)
                    objConnection.Close();
            }
        }
        #endregion Function - Delete
    }
}