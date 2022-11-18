using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class AddPatient : System.Web.UI.Page
    {
        PatientHelper patHelper = new PatientHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSavePatient_Click(object sender, EventArgs e)
        {
            EntityLayer.User usr = new EntityLayer.User();
            usr.Email = txtEmail.Text;
            usr.Name = txtName.Text;
            usr.Password = txtPassword.Text;
            usr.Username = txtUsername.Text;
            usr.Address = txtAddress.Text;
            usr.UserType = "P";
            bool isAdded = patHelper.AddPatient(usr);
            if (isAdded)
            {
                Response.Write("<script>alert('Patient saved successfully.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
            }
        }
    }
}