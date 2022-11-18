using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class RoomHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool AddRoom(EntityLayer.RoomData rmdt)
        {
            bool isRoomAdded = false;

            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    Room rm = new Room();
                    rm.BedsCount = rmdt.BedsCount;
                    rm.Description = rmdt.Description;
                    rm.Name = rmdt.Name;
                    uow.RoomRepository.Insert(rm);
                    uow.Save();
                    isRoomAdded = true;
                }
            }
            catch (Exception)
            {
                isRoomAdded = false;
            }

            return isRoomAdded;
        }

        public List<RoomData> GetAllRooms()
        {
            List<RoomData> lstRooms = new List<RoomData>();

            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    lstRooms = uow.RoomRepository.Get().Select(rm => new RoomData
                     {
                         BedsCount = rm.BedsCount,
                         Description = rm.Description,
                         Name = rm.Name,
                         RoomID = rm.RoomID
                     }).ToList();
                }
            }
            catch (Exception)
            {

                lstRooms = null;
            }

            return lstRooms;
        }

        public bool AddRoomAssign(EntityLayer.RoomData rmdt)
        {
            bool isRoomAssignAdded = false;

            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    RoomAssign rm = new RoomAssign();
                    rm.PatientID = rmdt.PatientID;
                    rm.RoomID = rmdt.RoomID;
                    rm.Savedon = DateTime.Now.ToString();
                    rm.AssignDate = rmdt.AssignDate;
                    uow.RoomAssignRepository.Insert(rm);
                    uow.Save();
                    isRoomAssignAdded = true;
                }
            }
            catch (Exception)
            {
                isRoomAssignAdded = false;
            }

            return isRoomAssignAdded;
        }

        public List<RoomData> GetAssignedRoomData()
        {
            List<RoomData> lstRooms = new List<RoomData>();

            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    lstRooms = uow.RoomAssignRepository.SQLQuery<RoomData>("Select pt.Name,rm.Name as RoomName,ra.RoomAssignID,ra.AssignDate,ra.Savedon from Users pt join RoomAssign ra on pt.UserID=ra.PatientID join Room rm on rm.RoomID=ra.RoomID;").ToList();
                }
            }
            catch (Exception)
            {

                lstRooms = null;
            }

            return lstRooms;
        }

    }
}
