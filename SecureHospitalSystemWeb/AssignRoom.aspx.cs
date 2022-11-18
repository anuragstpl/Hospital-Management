using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using System.Drawing;

namespace DoctorAppointmentWeb
{
    public partial class AssignRoom : System.Web.UI.Page
    {
        PatientHelper patHelper = new PatientHelper();
        RoomHelper roomHelper = new RoomHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPatient();
                LoadRoom();
                LoadRoomAssignation();
            }
        }

        protected void btnAssignRoom_Click(object sender, EventArgs e)
        {
            RoomData rmdata = new RoomData();
            rmdata.PatientID = Convert.ToInt32(ddlPatient.SelectedValue);
            rmdata.RoomID = Convert.ToInt32(ddlRoom.SelectedValue);
            rmdata.AssignDate = txtAssignedDate.Text;
            if (roomHelper.AddRoomAssign(rmdata))
            {
                lblMessage.Text = "Room assigned successfully.";
                lblMessage.ForeColor = Color.Green;
                LoadRoomAssignation();
            }
            else
            {
                lblMessage.Text = "Some error occured.";
                lblMessage.ForeColor = Color.Red;
            }
        }

        public void LoadPatient()
        {
            List<User> lstuser = patHelper.GetAllPatient();
            ddlPatient.DataSource = lstuser;
            ddlPatient.DataTextField = "Username";
            ddlPatient.DataValueField = "UserID";
            ddlPatient.DataBind();
        }

        public void LoadRoom()
        {
            List<RoomData> lstrooms = roomHelper.GetAllRooms();
            ddlRoom.DataSource = lstrooms;
            ddlRoom.DataTextField = "Name";
            ddlRoom.DataValueField = "RoomID";
            ddlRoom.DataBind();
        }

        public void LoadRoomAssignation()
        {
            List<RoomData> lstrooms = roomHelper.GetAssignedRoomData();
            lstRoomAssigns.DataSource = lstrooms;
            lstRoomAssigns.DataBind();
        }

        protected void lstRoomAssigns_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

    }
}