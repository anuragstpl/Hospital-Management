using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;

namespace DataLayer.DataHelper
{
    public class HealthRecordHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;
        public bool AddHealthRecord(HealthData healthRecord)
        {
            bool isAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    HealthRecord healthrecorddb = new HealthRecord();
                    healthrecorddb.Allergies = healthRecord.Allergies;
                    healthrecorddb.BloodGroup = healthRecord.BloodGroup;
                    healthrecorddb.ChronicDisease = healthRecord.ChronicDisease;
                    healthrecorddb.DateOfBirth = healthRecord.DateOfBirth;
                    healthrecorddb.EmergencyContactInfo = healthRecord.EmergencyContactInfo;
                    healthrecorddb.MajorIllness = healthRecord.MajorIllness;
                    healthrecorddb.PatientID = healthRecord.PatientID;
                    healthrecorddb.Surgeries = healthRecord.Surgeries;
                    uow.HealthRecordRepository.Insert(healthrecorddb);
                    uow.Save();
                    isAdded = true;
                }
                catch
                {
                    isAdded = false;
                }
            }

            return isAdded;
        }

        public bool UpdateHealthRecord(HealthData healthRecord)
        {
            bool isUpdated = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    HealthRecord healthrecorddb = new HealthRecord();
                    healthrecorddb.Allergies = healthRecord.Allergies;
                    healthrecorddb.BloodGroup = healthRecord.BloodGroup;
                    healthrecorddb.ChronicDisease = healthRecord.ChronicDisease;
                    healthrecorddb.DateOfBirth = healthRecord.DateOfBirth;
                    healthrecorddb.EmergencyContactInfo = healthRecord.EmergencyContactInfo;
                    healthrecorddb.MajorIllness = healthRecord.MajorIllness;
                    healthrecorddb.PatientID = healthRecord.PatientID;
                    healthrecorddb.Surgeries = healthRecord.Surgeries;
                    healthrecorddb.HealthRecordID = healthRecord.HealthRecordID;
                    uow.HealthRecordRepository.Update(healthrecorddb);
                    uow.Save();
                    isUpdated = true;
                }
                catch
                {
                    isUpdated = false;
                }
            }

            return isUpdated;
        }

    }
}
