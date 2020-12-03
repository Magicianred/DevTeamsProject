using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class DevTeamRepo
    {
        public List<DevTeam> _listOfTeams = new List<DevTeam>();

        //create
        public void addDevToTeam(DevTeam dev)
        {
            _listOfTeams.Add(dev);
        }

        //read
        public List<DevTeam> GetTeamInfo()
        {
            return _listOfTeams;
        }

        //update
        public bool UpdateExistingTeam(int originalTeam, DevTeam newTeam)
        {
            //find team
            DevTeam oldTeam = GetTeamByIdNum(originalTeam);

            //update team
            if (oldTeam != null)
            {
                oldTeam.TeamMember = newTeam.TeamMember;
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamId = newTeam.TeamId;

                return false;
            }
            else
            {
                return false;
            }
        }

        //delete
        public bool RemoveDevFromTeam(int id)
        {
            DevTeam teamMember = GetTeamByIdNum(id);

            if (teamMember == null)
            {
                return false;
            }

            int initialCount = _listOfTeams.Count;
            _listOfTeams.Remove(teamMember);

            if (initialCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public DevTeam GetTeamByIdNum(int id)
        {
            foreach (DevTeam team in _listOfTeams)
            {
                if (team.TeamId == id)
                {
                    return team;
                }
            }
            return null;
        }

    }
}
