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
    public partial class WebForm4 : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillBookingGridView();
            }
        }
        #endregion Load Event

        #region GridView

        #region FillGridView
        private void FillBookingGridView()
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
                        objCmd.CommandText = "PR_ServiceBooking_SelectAll";
                        #endregion Prepare Command

                        SqlDataReader objSDR = objCmd.ExecuteReader();
                        DataTable dtServiceBooking = new DataTable();
                        dtServiceBooking.Load(objSDR);

                        gvServiceBooking.DataSource = dtServiceBooking;
                        gvServiceBooking.DataBind();
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
        protected void gvServiceBooking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                DeleteBooking(Convert.ToInt32(e.CommandArgument));
                FillBookingGridView();
            }
            #endregion Delete Record
        }
        #endregion Grid Row Command

        #endregion GridView

        #region Function - Delete Booking
        private void DeleteBooking(Int32 ServiceBookingID)
        {
            SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString);
            try
            {
                objConnection.Open();

                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConnection;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ServiceBooking_DeleteBYPK";
                objCmd.Parameters.AddWithValue("@ServiceBookingID", ServiceBookingID);

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
        #endregion Function - Delete Booking
    }
}