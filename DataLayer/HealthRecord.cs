//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class HealthRecord
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
