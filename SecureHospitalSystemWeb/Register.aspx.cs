using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class Register : System.Web.UI.Page
    {
        DoctorHelper docHelper = new DoctorHelper();
        PractiontinarHelper prHelper = new PractiontinarHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            EntityLayer.User usr = new EntityLayer.User();
            usr.Email = txtEmail.Text;
            usr.Name = txtName.Text;
            usr.Password = txtPassword.Text;
            usr.Username = txtUserName.Text;
            usr.Speciality = txtSpeciality.Text;
            if (drpUserType.SelectedValue == "D")
            {
                bool isAdded = docHelper.RegisterDoctor(usr);
                if (isAdded)
                {
                    Response.Write("<script>alert('Doctor saved successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Some error occured.');</script>");
                }
            }
            else
            {
                bool isAdded = prHelper.RegisterPractioner(usr);
                if (isAdded)
                {
                    Response.Write("<script>alert('Practitioner saved successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Some error occured.');</script>");
                }
            }
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}