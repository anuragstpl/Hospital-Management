using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        SecureHospitalEntities context = new SecureHospitalEntities();

        SecureHospitalRepository<User> userRepository;
        SecureHospitalRepository<HealthRecord> healthRecordsRepository;
        SecureHospitalRepository<Appointment> appointmentRepository;
        SecureHospitalRepository<Room> roomRepository;
        SecureHospitalRepository<RoomAssign> roomAssignRepository;
        SecureHospitalRepository<Prescription> prescriptionRepository;
        SecureHospitalRepository<PrescriptionMedicine> prescriptionMedicineRepository;

        public SecureHospitalRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new SecureHospitalRepository<User>(context);
                return userRepository;
            }
        }

        public SecureHospitalRepository<Room> RoomRepository
        {
            get
            {
                if (this.roomRepository == null)
                    this.roomRepository = new SecureHospitalRepository<Room>(context);
                return roomRepository;
            }
        }

        public SecureHospitalRepository<RoomAssign> RoomAssignRepository
        {
            get
            {
                if (this.roomAssignRepository == null)
                    this.roomAssignRepository = new SecureHospitalRepository<RoomAssign>(context);
                return roomAssignRepository;
            }
        }

        public SecureHospitalRepository<HealthRecord> HealthRecordRepository
        {
            get
            {
                if (this.healthRecordsRepository == null)
                    this.healthRecordsRepository = new SecureHospitalRepository<HealthRecord>(context);
                return healthRecordsRepository;
            }
        }

        public SecureHospitalRepository<Appointment> AppointmentRepository
        {
            get
            {
                if (this.appointmentRepository == null)
                    this.appointmentRepository = new SecureHospitalRepository<Appointment>(context);
                return appointmentRepository;
            }
        }

        public SecureHospitalRepository<Prescription> PrescriptionRepository
        {
            get
            {
                if (this.prescriptionRepository == null)
                    this.prescriptionRepository = new SecureHospitalRepository<Prescription>(context);
                return prescriptionRepository;
            }
        }

        public SecureHospitalRepository<PrescriptionMedicine> PrescriptionMedicineRepository
        {
            get
            {
                if (this.prescriptionMedicineRepository == null)
                    this.prescriptionMedicineRepository = new SecureHospitalRepository<PrescriptionMedicine>(context);
                return prescriptionMedicineRepository;
            }
        }
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<T> SQLQuery<T>(string sql)
        {
            return context.Database.SqlQuery<T>(sql);
        }

        public virtual IEnumerable<T> SQLQueryWithParameters<T>(string sql, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(sql, parameters);
        }

    }
}
