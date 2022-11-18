using DHTMLX.Common;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using System.Web.SessionState;
using DataLayer.Helper;
using DataLayer.DataHelper;

namespace DoctorAppointmentWeb
{
    /// <summary>
    /// Summary description for Save
    /// </summary>
    public class Save : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";// the data is passed in XML format

            var action = new DataAction(context.Request.Form);
            var data = new AppointmentClassesDataContext();
            bool requiresSession = false;
            if (context.Handler is IRequiresSessionState)
            {
                requiresSession = true;
            }

            try
            {
                //var changedEvent = (Appointment)DHXEventsHelper.Bind(typeof(Appointment), context.Request.Form);//see details below

                Appointment changedEvent = new Appointment();
                changedEvent.Description = context.Request.Form["text"];
                changedEvent.EndTo = context.Request.Form["end_date"];
                changedEvent.StartsFrom = context.Request.Form["start_date"];
                if (requiresSession == true)
                {
                    if (context.Session["UserId"] != null)
                    {
                        changedEvent.DoctorID = Convert.ToInt32(context.Session["UserId"]);
                    }
                    else
                    {
                        changedEvent.DoctorID = Convert.ToInt32(context.Session["MSID"]);
                    }
                    changedEvent.PatientID = Convert.ToInt32(context.Session["PatID"]);
                }
                switch (action.Type)
                {
                    case DataActionTypes.Insert: // your Insert logic
                        data.Appointments.InsertOnSubmit(changedEvent);
                        EmailHelper emailHelper = new EmailHelper();
                        PatientHelper patHelper = new PatientHelper();
                        EntityLayer.User user = patHelper.GetAllPatient().Where(xd => xd.UserID == changedEvent.PatientID).FirstOrDefault();
                        DataLayer.User usr = new DataLayer.User();
                        usr.Email = user.Email;
                        usr.Name = user.Name;
                        usr.Username = user.Username;
                        emailHelper.SendAppointmentEmail(usr);
                        break;
                    case DataActionTypes.Delete: // your Delete logic
                        changedEvent = data.Appointments.SingleOrDefault(ev => ev.AppointmentID == action.SourceId);
                        data.Appointments.DeleteOnSubmit(changedEvent);
                        break;
                    default:// "update" // your Update logic
                        var updated = data.Appointments.SingleOrDefault(ev => ev.AppointmentID == action.SourceId);
                        DHXEventsHelper.Update(updated, changedEvent, new List<string>() { "AppointmentID" });// see details below
                        break;
                }
                data.SubmitChanges();
                action.TargetId = changedEvent.AppointmentID;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            context.Response.Write(new AjaxSaveResponse(action));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }
}