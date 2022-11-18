using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class AddAppointment : System.Web.UI.Page
    {
        PatientHelper patHelper = new PatientHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                drpPatient.DataSource = patHelper.GetAllPatient();
                drpPatient.DataTextField = "Username";
                drpPatient.DataValueField = "UserID";
                drpPatient.DataBind();
            }
        }

        protected void btnAddAppointment_Click(object sender, EventArgs e)
        {

        }

    }
}