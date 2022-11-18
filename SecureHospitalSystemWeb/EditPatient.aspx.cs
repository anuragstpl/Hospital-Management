using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class EditPatient : System.Web.UI.Page
    {
        PatientHelper patHelper = new PatientHelper();
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                userid = Convert.ToInt32(Request.QueryString["id"].ToString());
                EntityLayer.User usr = patHelper.GetAllPatient().Where(x => x.UserID == userid).FirstOrDefault();
                txtEmail.Text = usr.Email;
                txtName.Text = usr.Name;
                txtUsername.Text = usr.Username;
                txtPassword.Text = usr.Password;
                txtAddress.Text = usr.Address;
            }
        }

        protected void btnEditPatient_Click(object sender, EventArgs e)
        {
            userid=Convert.ToInt32(Request.QueryString["id"].ToString());
            EntityLayer.User usr = new EntityLayer.User();
            usr.Email = txtEmail.Text;
            usr.Name = txtName.Text;
            usr.Password = txtPassword.Text;
            usr.Username = txtUsername.Text;
            usr.Address = txtAddress.Text;
            usr.UserType = "P";
            usr.UserID = userid;
            bool isAdded = patHelper.EditPatient(usr);
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