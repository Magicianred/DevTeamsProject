using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class Developer
    {
        public string Name { get; set; }
        public int IdNumber { get; set; }
        public bool PluralsightAccess { get; set; }


        public Developer() { }
        public Developer(string name, int idNumber, bool pluralsightAccess)
        {
            Name = name;
            IdNumber = idNumber;
            PluralsightAccess = pluralsightAccess;
        }
    }
}
