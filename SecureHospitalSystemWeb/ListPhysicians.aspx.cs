using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class ListPhysicians : System.Web.UI.Page
    {
        DoctorHelper docHelper = new DoctorHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindNurses();
            }
        }

        private void BindNurses()
        {
            List<EntityLayer.User> lstDocs = docHelper.GetAllPhysician();
            lstDoctors.DataSource = lstDocs;
            lstDoctors.DataBind();
        }



        protected void lstDoctors_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstDoctors.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindNurses();

        }
    }
}