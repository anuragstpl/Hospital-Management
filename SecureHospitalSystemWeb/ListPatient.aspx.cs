using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class ListPatient : System.Web.UI.Page
    {
        PatientHelper patHelper = new PatientHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindPatient();
            }
        }

        private void BindPatient()
        {
            List<EntityLayer.User> lstPatient = patHelper.GetAllPatient();
            lstCustomers.DataSource = lstPatient;
            lstCustomers.DataBind();
        }

        protected void lstCustomers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("EditPatient.aspx?id=" + e.CommandArgument);
            }
            else
                if (e.CommandName == "Document")
                {
                    Response.Redirect("PatientHealthRecord.aspx?id=" + e.CommandArgument);
                }
                else
                    if (e.CommandName == "Delete")
                    {
                        patHelper.DeletePatient(Convert.ToInt32(e.CommandArgument));
                        this.BindPatient();
                    }
                    else
                        if (e.CommandName == "Appointment")
                        {
                            Response.Redirect("SetAppointment.aspx?id=" + e.CommandArgument);
                        }
                        else
                            if (e.CommandName == "Prescribe")
                            {
                                Response.Redirect("Prescription.aspx?patid=" + e.CommandArgument);
                            }
        }

        protected void lstCustomers_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstCustomers.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindPatient();
        }

        protected void lstCustomers_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
           
        }
    }
}