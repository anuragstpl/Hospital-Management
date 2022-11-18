using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class PrescriptionHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;
        public bool AddPrescription(List<PrescriptionData> prescriptionData)
        {
            bool isAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Prescription prescriptionDb = new Prescription();
                    prescriptionDb.PatientID = prescriptionData.FirstOrDefault().PatientID;
                    prescriptionDb.DoctorID = prescriptionData.FirstOrDefault().DoctorID;
                    prescriptionDb.PrescriptionDate = prescriptionData.FirstOrDefault().PrescriptionDate;

                    uow.PrescriptionRepository.Insert(prescriptionDb);
                    uow.Save();
                    prescriptionDb.PrescriptionID = prescriptionDb.PrescriptionID;

                    foreach (PrescriptionData item in prescriptionData)
                    {
                        PrescriptionMedicine presMedicine = new PrescriptionMedicine();
                        presMedicine.Frequency = item.Frequency;
                        presMedicine.Medicine = item.Medicine;
                        presMedicine.PrescriptionID = prescriptionDb.PrescriptionID;
                        uow.PrescriptionMedicineRepository.Insert(presMedicine);
                        uow.Save();
                    }

                    isAdded = true;
                }
                catch
                {
                    isAdded = false;
                }
            }

            return isAdded;
        }

        public List<PrescriptionData> GetPrescriptionForPatient(int patintID)
        {
            List<PrescriptionData> lstPrescription = new List<PrescriptionData>();

            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    lstPrescription = uow.SQLQueryWithParameters<PrescriptionData>("GetPatientPrescription @patientID", new SqlParameter("patientID", patintID)).ToList();
                }
            }
            catch
            {
                lstPrescription = null;
            }

            return lstPrescription;
        }
    }
}
