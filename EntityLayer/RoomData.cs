using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class RoomData
    {
        public int RoomID { get; set; }
        public Nullable<int> BedsCount { get; set; }
        public string Name { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public int RoomAssignID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public string AssignDate { get; set; }
        public string Savedon { get; set; }
    }
}
