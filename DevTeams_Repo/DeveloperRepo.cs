using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class DeveloperRepo
    {
        public List<Developer> _listOfDevelopers = new List<Developer>();

        //create
        public void addNewDev(Developer dev)
        {
            _listOfDevelopers.Add(dev);
        }

        //read
        public List<Developer> GetDevInfo()
        {
            return _listOfDevelopers;
        }

        //update
        public bool UpdateExistingDev(int originalDev, Developer newDeveloper)
        {
            //find dev
            Developer oldDev = GetDeveloperById(originalDev);

            //update dev
            if (oldDev != null)
            {
                oldDev.IdNumber = newDeveloper.IdNumber;
                oldDev.Name = newDeveloper.Name;
                oldDev.PluralsightAccess = newDeveloper.PluralsightAccess;

                return true;
            }
            else
            {
                return false;
            }
        }

        //delete
        public bool RemoveDevFromList(int id)
        {
            Developer dev = GetDeveloperById(id);

            if (dev == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(dev);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public Developer GetDeveloperById(int id)
        {
            foreach (Developer dev in _listOfDevelopers)
            {
                if (dev.IdNumber == id)
                {
                    return dev;
                }
            }

            return null;
        }
    }
}
