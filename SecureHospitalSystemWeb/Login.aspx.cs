using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer.DataHelper;
using EntityLayer;

namespace DoctorAppointmentWeb
{
    public partial class Login : System.Web.UI.Page
    {
        DoctorHelper docHelper = new DoctorHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.QueryString["name"].ToString();
            EntityLayer.User user = new User();
            user = docHelper.LoginUser(username);
            if (user != null)
            {
                Session["MSID"] = user.UserID;
                Session["Name"] = user.Name;
                Session["UserType"] = "M";
                Response.Redirect("ListPatient.aspx");
            }
        }

      
    }
}