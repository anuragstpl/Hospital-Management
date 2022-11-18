using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.UnitOfWork;

namespace DataLayer.DataHelper
{
    public class DoctorHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool RegisterDoctor(EntityLayer.User user)
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
                    userdb.UserType = user.UserType;
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

        public EntityLayer.User LoginUser(string usr, string pwd, string usertype)
        {
            EntityLayer.User usrdt = new EntityLayer.User();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    User usd = uow.UserRepository.Get().Where(x => x.Username == usr && x.Password == pwd && x.UserType == usertype).FirstOrDefault();
                    usrdt.Email = usd.Email;
                    usrdt.Name = usd.Name;
                    usrdt.UserID = usd.UserID;
                    usrdt.Username = usd.Username;

                }
                catch
                {
                    usrdt = null;   
                }
            }
            return usrdt;
        }

        public EntityLayer.User LoginUser(string usr)
        {
            EntityLayer.User usrdt = new EntityLayer.User();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    User usd = uow.UserRepository.Get().Where(x => x.Username == usr).FirstOrDefault();
                    usrdt.Email = usd.Email;
                    usrdt.Name = usd.Name;
                    usrdt.UserID = usd.UserID;
                    usrdt.Username = usd.Username;

                }
                catch
                {
                    usrdt = null;
                }
            }
            return usrdt;
        }

        public List<EntityLayer.User> GetAllDoctors()
        {
            List<EntityLayer.User> lstUsers = new List<EntityLayer.User>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstUsers = uow.UserRepository.Get().Where(usr => usr.UserType == "D").Select(usd => new EntityLayer.User
                    {
                        Address = usd.Address,
                        Email = usd.Email,
                        Name = usd.Name,
                        Username = usd.Username,
                        UserID = usd.UserID,
                        Speciality=usd.Speciality

                    }).ToList();
                }
                catch
                {

                }
            }
            return lstUsers;
        }

        public List<EntityLayer.User> GetAllNurses()
        {
            List<EntityLayer.User> lstUsers = new List<EntityLayer.User>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstUsers = uow.UserRepository.Get().Where(usr => usr.UserType == "N").Select(usd => new EntityLayer.User
                    {
                        Address = usd.Address,
                        Email = usd.Email,
                        Name = usd.Name,
                        Username = usd.Username,
                        UserID = usd.UserID,
                        Speciality = usd.Speciality

                    }).ToList();
                }
                catch
                {

                }
            }
            return lstUsers;
        }

        public List<EntityLayer.User> GetAllPhysician()
        {
            List<EntityLayer.User> lstUsers = new List<EntityLayer.User>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstUsers = uow.UserRepository.Get().Where(usr => usr.UserType == "M").Select(usd => new EntityLayer.User
                    {
                        Address = usd.Address,
                        Email = usd.Email,
                        Name = usd.Name,
                        Username = usd.Username,
                        UserID = usd.UserID,
                        Speciality = usd.Speciality

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
