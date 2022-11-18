using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class HealthData
    {
        public int HealthRecordID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public string BloodGroup { get; set; }
        public string DateOfBirth { get; set; }
        public Nullable<bool> Allergies { get; set; }
        public string MajorIllness { get; set; }
        public string Surgeries { get; set; }
        public string ChronicDisease { get; set; }
        public string EmergencyContactInfo { get; set; }
    }
}
