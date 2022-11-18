using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class ListDoctors : System.Web.UI.Page
    {
        DoctorHelper docHelper = new DoctorHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindDoctors();
            }
        }

        private void BindDoctors()
        {
            List<EntityLayer.User> lstDocs = docHelper.GetAllDoctors();
            lstDoctors.DataSource = lstDocs;
            lstDoctors.DataBind();
        }

        protected void lstDoctors_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Appointment")
            {
                Response.Redirect("SetAppointment.aspx?DocId=" + e.CommandArgument);
            }
        }

        protected void lstDoctors_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstDoctors.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindDoctors();
            
        }
    }
}