using DHTMLX.Scheduler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentWeb
{
    /// <summary>
    /// Summary description for Data
    /// </summary>
    public class Data : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";// the data comes in JSON format
            context.Response.Write(
                new SchedulerAjaxData(new AppointmentClassesDataContext().Appointments) //events for loading to scheduler
            );
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