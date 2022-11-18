using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class AddRoom : System.Web.UI.Page
    {
        RoomHelper rmHelper = new RoomHelper();
        protected void Page_Load(object sender, EventArgs e)    
        {

        }

        protected void btnAddRoom_Click(object sender, EventArgs e)
        {
            EntityLayer.RoomData rmData = new EntityLayer.RoomData();
            rmData.Name = txtName.Text;
            rmData.BedsCount = Convert.ToInt32(txtBedCount.Text);
            rmData.Description = txtDescription.Text;
            if (rmHelper.AddRoom(rmData))
            Response.Write("<script>alert('Room added successfully');</script>");
            else
            Response.Write("<script>alert('Some error occured.');</script>") ;
        }
    }
}