using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class PractiontinarHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool RegisterPractioner(EntityLayer.User user)
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
    }
}
