using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Manager
{
    class Teacher
    {
        public string FirstName;
        public string LastName;
        public string ID;
        public string PayCheck;
        public string DateJoined;
        public string WeeklyHours;
        public string HomeRoomTeacher; // "None" if the teacher isn't in charge of a homeroom
        public string[] Subjects;
    }
}
