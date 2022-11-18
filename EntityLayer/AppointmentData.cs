using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class AppointmentData
    {
        public int id { get; set; }
        public string Subject { get; set; }
        public Nullable<int> PatientID { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public Nullable<int> DoctorID { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public bool allday { get; set; }
    }
}
