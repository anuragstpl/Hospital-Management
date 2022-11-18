using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class PatientHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool AddPatient(EntityLayer.User user)
        {
            bool isRegsitered = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    User userdb = new User();
                    userdb.Address = user.Address;
                    userdb.Email = user.Email;
                    userdb.Name = user.Name;
                    userdb.Password = user.Password;
                    userdb.Speciality = user.Speciality;
                    userdb.Username = user.Username;
                    userdb.UserType = "P";
                    uow.UserRepository.Insert(userdb);
                    uow.Save();
                    isRegsitered = true;
                }
                catch
                {
                    isRegsitered = false;
                }
            }

            return isRegsitered;
        }

        public bool EditPatient(EntityLayer.User user)
        {
            bool isEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    User userdb = uow.UserRepository.Get().Where(u => u.UserID.Equals(user.UserID)).FirstOrDefault();
                    userdb.Address = user.Address;
                    userdb.Email = user.Email;
                    userdb.Name = user.Name;
                    userdb.Password = user.Password;
                    userdb.Speciality = user.Speciality;
                    userdb.Username = user.Username;
                    userdb.UserID = user.UserID;
                    uow.UserRepository.Update(userdb);
                    uow.Save();
                    isEdited = true;
                }
                catch
                {
                    isEdited = false;
                }
            }

            return isEdited;
        }

        public bool DeletePatient(int UserID)
        {
            bool isDeleted = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    uow.UserRepository.Delete(UserID);
                    uow.Save();
                    isDeleted = true;
                }
                catch
                {
                    isDeleted = false;
                }

                return isDeleted;
            }
        }

        public List<EntityLayer.User> GetAllPatient()
        {
            List<EntityLayer.User> lstUsers = new List<EntityLayer.User>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstUsers = uow.UserRepository.Get().Where(usr => usr.UserType == "P").Select(usd => new EntityLayer.User
                     {
                         Address = usd.Address,
                         Email = usd.Email,
                         Name = usd.Name,
                         Username = usd.Username,
                         UserID = usd.UserID

                     }).ToList();
                }
                catch
                {

                }
            }
            return lstUsers;
        }
    }
}
