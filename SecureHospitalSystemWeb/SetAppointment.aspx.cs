using DataLayer.DataHelper;
using DHTMLX.Scheduler;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentWeb
{
    public partial class SetAppointment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["MSID"] = 9;
            string PatientID = Request.QueryString["id"].ToString();
            Session["PatID"] = PatientID;
            //string DocID = Session["MSID"].ToString();
            //Session["DrID"] = DocID;
            //this.Scheduler = new DHXScheduler();

            //Scheduler.InitialDate = new DateTime(2016, 11, 24);// the initial data of Scheduler

            //Scheduler.Config.first_hour = 8;//the minimum value of the hour scale
            //Scheduler.Config.last_hour = 19;//the maximum value of the hour scale
            //Scheduler.Config.time_step = 30;//the scale interval for the time selector in the lightbox
            //Scheduler.Config.limit_time_select = true;//sets max and min values for the time selector in the lightbox to the values of the last_hour and first_hour options

            //Scheduler.DataAction = this.ResolveUrl("~/Data.ashx");// the handler which defines loading data to Scheduler
            //Scheduler.SaveAction = this.ResolveUrl("~/Save.ashx");// the handler which defines create/update/delete logic
            //Scheduler.LoadData = true;
            //Scheduler.EnableDataprocessor = true;
        }

        //called when Add button is clicked
        //this is called when a mouse is clicked on open space of any day or dragged 
        //over mutliple days
        [System.Web.Services.WebMethod]
        public static int addEvent(AppointmentData improperEvent)
        {
            AppointmentHelper aptsHelper = new AppointmentHelper();
            return aptsHelper.AddAppointment(improperEvent);
        }

        AppointmentHelper aptHelper = new AppointmentHelper();
        //this method only updates title and description
        //this is called when a event is clicked on the calendar
        [System.Web.Services.WebMethod(true)]
        public static string UpdateEvent(AppointmentData cevent)
        {
            List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(cevent.id))
            {
                if (CheckAlphaNumeric(cevent.title) && CheckAlphaNumeric(cevent.description))
                {

                    AppointmentHelper aptHelpr = new AppointmentHelper();
                    aptHelpr.UpdateAppointmentData(cevent);

                    return "updated event with id:" + cevent.id + " update title to: " + cevent.title +
                    " update description to: " + cevent.description;
                }

            }

            return "unable to update event with id:" + cevent.id + " title : " + cevent.title +
                " description : " + cevent.description;
        }

        //this method only updates start and end time
        //this is called when a event is dragged or resized in the calendar
        [System.Web.Services.WebMethod(true)]
        public static string UpdateEventTime(AppointmentData cevent)
        {
            List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
            if (idList != null && idList.Contains(cevent.id))
            {


                AppointmentHelper aptHelpr = new AppointmentHelper();
                aptHelpr.UpdateAppointmentTime(cevent);

                return "updated event with id:" + cevent.id + " update title to: " + cevent.title +
                " update description to: " + cevent.description;


            }

            return "unable to update event with id:" + cevent.id + " title : " + cevent.title +
                " description : " + cevent.description;
        }

        //called when delete button is pressed
        [System.Web.Services.WebMethod(true)]
        public static String deleteEvent(int id)
        {
            //idList is stored in Session by JsonResponse.ashx for security reasons
            //whenever any event is update or deleted, the event id is checked
            //whether it is present in the idList, if it is not present in the idList
            //then it may be a malicious user trying to delete someone elses events
            //thus this checking prevents misuse
            AppointmentHelper aptHelpr = new AppointmentHelper();
            if (aptHelpr.DeleteAppointment(id))
            {
                return "deleted event with id:" + id;
            }
            else
            {
                return "unable to delete event with id: " + id;
            }
        }



        private static bool CheckAlphaNumeric(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z0-9 ]*$");
        }
    }
}