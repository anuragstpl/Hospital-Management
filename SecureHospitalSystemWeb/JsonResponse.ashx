<%@ WebHandler Language="C#" Class="JsonResponse" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.SessionState;
using EntityLayer;
using DataLayer.DataHelper;
using System.Globalization;

public class JsonResponse : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        DateTime start = Convert.ToDateTime(context.Request.QueryString["start"]);
        DateTime end = Convert.ToDateTime(context.Request.QueryString["end"]);

        List<int> idList = new List<int>();
        List<AppointmentData> tasksList = new List<AppointmentData>();
        AppointmentHelper aptHelper = new AppointmentHelper();
        //Generate JSON serializable events
        foreach (AppointmentData cevent in aptHelper.GetEvents())
        {

            tasksList.Add(new AppointmentData
            {
                id = cevent.id,
                start = String.Format("{0:s}", DateTime.Parse(cevent.start).ToUniversalTime()),
                end = String.Format("{0:s}", DateTime.Parse(cevent.end).ToUniversalTime()),
                description = cevent.description,
                title = cevent.title
            });
            idList.Add(cevent.id);
        }

        context.Session["idList"] = idList;

        //Serialize events to string
        System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        string sJSON = oSerializer.Serialize(tasksList);

        //Write JSON to response object
        context.Response.Write(sJSON);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}