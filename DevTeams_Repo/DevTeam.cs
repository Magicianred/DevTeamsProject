using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class DevTeam
    {
        public string TeamMember { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }

        public DevTeam() { }
        public DevTeam(string teamMember, string teamName, int teamId)
        {
            TeamMember = teamMember;
            TeamName = teamName;
            TeamId = teamId;
        }
    }
}
