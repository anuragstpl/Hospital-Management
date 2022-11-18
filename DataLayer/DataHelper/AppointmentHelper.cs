using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DataLayer.DataHelper
{
    public class AppointmentHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;
        public int AddAppointment(AppointmentData appointment)
        {
            int isAdded = -1;
            try
            {
                Appointment apt = new Appointment();
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    string patientid = HttpContext.Current.Session["PatID"].ToString();
                    apt.Description = appointment.description;
                    apt.DoctorID = Convert.ToInt32(HttpContext.Current.Session["MSID"].ToString());
                    apt.EndTo = appointment.end;
                    apt.PatientID = Convert.ToInt32(patientid);
                    apt.StartsFrom = appointment.start;
                    apt.Title = appointment.title;
                    uow.AppointmentRepository.Insert(apt);
                    uow.Save();
                    isAdded = apt.AppointmentID;
                    List<int> idList = (List<int>)System.Web.HttpContext.Current.Session["idList"];
                    idList.Add(isAdded);
                    System.Web.HttpContext.Current.Session["idList"] = idList;
                }
            }
            catch
            {

            }
            return isAdded;
        }


        public List<AppointmentData> GetEvents()
        {
            List<AppointmentData> lstEvents = new List<AppointmentData>();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    lstEvents = uow.AppointmentRepository.Get().Select(usd => new EntityLayer.AppointmentData
                    {
                        id = usd.AppointmentID,
                        description = usd.Description,
                        end = usd.EndTo,
                        start = usd.StartsFrom,
                        title = usd.Title
                    }).ToList();
                }
            }
            catch
            {

            }
            return lstEvents;
        }

        public bool DeleteAppointment(int id)
        {
            bool isDeleted = false;
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    Appointment apt = uow.AppointmentRepository.Get().Where(x => x.AppointmentID == id).FirstOrDefault();
                    uow.AppointmentRepository.Delete(apt);
                    uow.Save();
                    isDeleted = true;
                }
            }
            catch
            {

            }
            return isDeleted;
        }

        public bool UpdateAppointmentData(AppointmentData appointment)
        {
            bool isUpdated = false;
            try
            {

                using (uow = new UnitOfWork.UnitOfWork())
                {
                    Appointment apt = uow.AppointmentRepository.GetById(appointment.id);
                    apt.Description = appointment.description;
                    apt.Title = appointment.title;
                    uow.AppointmentRepository.Update(apt);
                    uow.Save();
                    isUpdated = true;
                }
            }
            catch
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public bool UpdateAppointmentTime(AppointmentData appointment)
        {
            bool isUpdated = false;
            try
            {

                using (uow = new UnitOfWork.UnitOfWork())
                {
                    Appointment apt = uow.AppointmentRepository.GetById(appointment.id);
                    apt.EndTo = appointment.end;
                    apt.StartsFrom = appointment.start;
                    uow.AppointmentRepository.Update(apt);
                    uow.Save();
                    isUpdated = true;
                }
            }
            catch
            {
                isUpdated = false;
            }
            return isUpdated;
        }
    }

}
