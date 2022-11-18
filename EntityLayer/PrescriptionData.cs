using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class PrescriptionData
    {
        public int PrescriptionID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public Nullable<int> DoctorID { get; set; }
        public string PrescriptionDate { get; set; }
        public int PrescribedMedicineID { get; set; }
        public string Medicine { get; set; }
        public string Frequency { get; set; }
    }
}
