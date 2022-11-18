using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class Prescription : System.Web.UI.Page
    {
        PrescriptionHelper presHelper = new PrescriptionHelper();
        DoctorHelper docHelper = new DoctorHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["DocID"] = 9;
                int docID = Convert.ToInt32(Session["DocID"]);
                EntityLayer.User user = new User();
                user = docHelper.GetAllDoctors().Where(x => x.UserID == docID).First();
                lblAddress.Text = user.Address;
                lblDocName.Text = user.Name;
                lblEmail.Text = user.Email;
                lblSpeciality.Text = user.Speciality;
            }
        }

        protected void btnSavePrescription_Click(object sender, EventArgs e)
        {
            int docID = Convert.ToInt32(Session["DocID"]);
            int patid = Convert.ToInt32(Request.QueryString["patid"]);
            List<PrescriptionData> lstpresData = new List<PrescriptionData>();
            PrescriptionData presdata1 = new PrescriptionData();
            presdata1.DoctorID = docID;
            presdata1.Frequency = ddlFrequency.SelectedItem.Text;
            presdata1.Medicine = txtMedicine1.Text;
            presdata1.PatientID = patid;
            presdata1.PrescriptionDate = DateTime.Now.ToString();
            lstpresData.Add(presdata1);

            PrescriptionData presdata2 = new PrescriptionData();
            presdata2.DoctorID = docID;
            presdata2.Frequency = ddlFrequency2.SelectedItem.Text;
            presdata2.Medicine = txtMedicine2.Text;
            presdata2.PatientID = patid;
            presdata2.PrescriptionDate = DateTime.Now.ToString();
            lstpresData.Add(presdata2);

            PrescriptionData presdata3 = new PrescriptionData();
            presdata3.DoctorID = docID;
            presdata3.Frequency = ddlFrequency3.SelectedItem.Text;
            presdata3.Medicine = txtMedicine3.Text;
            presdata3.PatientID = patid;
            presdata3.PrescriptionDate = DateTime.Now.ToString();
            lstpresData.Add(presdata3);

            PrescriptionData presdata4 = new PrescriptionData();
            presdata4.DoctorID = docID;
            presdata4.Frequency = ddlFrequency4.SelectedItem.Text;
            presdata4.Medicine = txtMedicine4.Text;
            presdata4.PatientID = patid;
            presdata4.PrescriptionDate = DateTime.Now.ToString();
            lstpresData.Add(presdata4);


            PrescriptionData presdata5 = new PrescriptionData();
            presdata5.DoctorID = docID;
            presdata5.Frequency = ddlFrequency5.SelectedItem.Text;
            presdata5.Medicine = txtMedicine5.Text;
            presdata5.PatientID = patid;
            presdata5.PrescriptionDate = DateTime.Now.ToString();
            lstpresData.Add(presdata5);

            bool isPrescriptionAdded = presHelper.AddPrescription(lstpresData);
            if (isPrescriptionAdded)
            {
                Response.Write("<script>alert('Prescription added successfully.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
            }
        }
    }
}