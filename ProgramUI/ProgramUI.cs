using DevTeams_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI
{
    public class ProgramUI
    {
        private DeveloperRepo _devRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        //method that starts app
        public void Run()
        {
            SeedDevList();
            Menu();
        }

        //menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //display options to user
                Console.WriteLine("Select a menu option:\n" +
                    "\n" +
                    "Individual Developer Options\n" +
                    "1. Add New Developer\n" +
                    "2. View Developer Information/Pluralsight Status\n" +
                    "3. Update Existing Developer Information\n" +
                    "4. Remove Developer From Program\n" +
                    "\n" +
                    "Team Developer Options\n" +
                    "5. Create New Team\n" +
                    "6. View Developer Team Information\n" +
                    "7. Update Existing Team information/ Add Developer to Team\n" +
                    "8. Remove Developer from Team\n" +
                    "\n" +
                    "9. Exit");

                //get user input
                string input = Console.ReadLine();

                //evaulate user input and act accordingly
                switch (input)
                {
                    case "1":
                        //add new dev
                        addNewDev();
                        break;
                    case "2":
                        //view dev info
                        viewDevInfo();
                        break;
                    case "3":
                        //update existing dev
                        updateExistingDev();
                        break;
                    case "4":
                        //remove dev
                        removeDev();
                        break;
                    case "5":
                        //create new team
                        newDevTeam();
                        break;
                    case "6":
                        //view dev team info
                        viewTeamInfo();
                        break;
                    case "7":
                        //update team into
                        UpdateExistingTeam();
                        break;
                    case "8":
                        //remove dev from team
                        RemoveDevFromTeam();
                        break;
                    case "9":
                        //exit
                        Console.WriteLine("Goodbye and have a great day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //add new dev
        private void addNewDev()
        {
            Console.Clear();

            Developer newDev = new Developer();

            //name
            Console.WriteLine("Please Enter Developer Name:");
            newDev.Name = Console.ReadLine();

            //id number
            Console.WriteLine("Please Enter Developer ID Number:");
            string IdNumAsString = Console.ReadLine();
            newDev.IdNumber = int.Parse(IdNumAsString);

            //pluralsight access
            Console.WriteLine("Does Developer Have Access to Pluralsight? (y/n)");
            string pluralsightAsString = Console.ReadLine().ToLower();
            if (pluralsightAsString == "y")
            {
                newDev.PluralsightAccess = true;
            }
            else
            {
                newDev.PluralsightAccess = false;
            }

        }

        //view dev info
        private void viewDevInfo()
        {
            Console.Clear();
            List<Developer> devInfo = _devRepo.GetDevInfo();
            foreach (Developer info in devInfo)
            {
                Console.WriteLine($"Name: {info.Name}, ID Number:{info.IdNumber}, Puralsight Access:{info.PluralsightAccess}");
            }
        }

        //update existing dev
        private void updateExistingDev()
        {
            //Display all content
            viewDevInfo();
            //ask for id of Dev to update
            Console.WriteLine("Please enter ID number of Developer you would like to update");
            int oldIdAsString = int.Parse(Console.ReadLine());

            //get dev
            //Developer developer = _devRepo.GetDeveloperById()
           

            //help

            //Developer oldDev = .GetDeveloperById(originalDev);

            //build new object
            Developer newDev = new Developer();


            //name
            Console.WriteLine("Please Enter New Developer Name:");
            newDev.Name = Console.ReadLine();

            //id number
            Console.WriteLine("Please Enter New Developer ID Number:");
            string IdNumAsString = Console.ReadLine();
            newDev.IdNumber = int.Parse(IdNumAsString);

            //pluralsight access
            Console.WriteLine("Does Developer Have Access to Pluralsight? (y/n)");
            string pluralsightAsString = Console.ReadLine().ToLower();
            if (pluralsightAsString == "y")
            {
                newDev.PluralsightAccess = true;
            }
            else
            {
                newDev.PluralsightAccess = false;
            }

            

            _devRepo.UpdateExistingDev(oldIdAsString, newDev);


        }

        //remove dev
        private void removeDev()
        {

            viewDevInfo();

            //get dev they want to remove
            Console.WriteLine("\nEnter ID of dev you would like to remove");

            Developer deleteDev = new Developer();

            int IdNumber = int.Parse(Console.ReadLine());
            //call delete method
           bool wasDeleted = _devRepo.RemoveDevFromList(IdNumber);

            //if content was deleted say so
            if (wasDeleted)
            {
                Console.WriteLine("Dev was successfully deleted");
            }
            //otherwise state could not be deleted 
            else
            {
                Console.WriteLine("Dev could not be deleted");
            }
        }

        //create new dev team
        private void newDevTeam()
        {
            DevTeam newDevTeam = new DevTeam();

            //team member
            Console.WriteLine("Enter developer name or ID:");
            newDevTeam.TeamMember = Console.ReadLine();
            //team name
            Console.WriteLine("Enter team name:");
            newDevTeam.TeamName = Console.ReadLine();
            //team id
            Console.WriteLine("Enter team ID number:");
            string teamIdasString = Console.ReadLine();
            newDevTeam.TeamId = int.Parse(teamIdasString);
        }

        //view dev team info
        private void viewTeamInfo()
        {
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetTeamInfo();
            foreach (DevTeam devteam in listOfDevTeams)
                Console.WriteLine($"Team Name: {devteam.TeamName}\n" +
                    $"Team ID: {devteam.TeamId} ");
            }


        //update dev team info
        private void UpdateExistingTeam()
        {
            viewTeamInfo();
            Console.WriteLine("Please enter ID of team you would like to update");

            int oldTeamId = int.Parse(Console.ReadLine());

            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Please Enter New Team Name:");
            newDevTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Please Enter New Team ID Number:");
            string TeamIdNumAsString = Console.ReadLine();
            newDevTeam.TeamId = int.Parse(TeamIdNumAsString);

            Console.WriteLine("Please Enter developer you would like to add");
            newDevTeam.TeamMember = Console.ReadLine();

            _devTeamRepo.UpdateExistingTeam(oldTeamId, newDevTeam);

            bool addAnotherDev = true;
            //add dev method
            while(addAnotherDev)
            {
                Console.WriteLine("Would you like to add another dev to this team?");

                string answer = Console.ReadLine();

                if (answer == "yes")
                {
                    //add dev method?
                    Console.WriteLine("Please Enter developer you would like to add");
                    newDevTeam.TeamMember = Console.ReadLine();
                }
                else
                {
                    addAnotherDev = false;
                }
            }


        }

        //remove dev from team
        private void RemoveDevFromTeam()
        {
            viewTeamInfo();
            Console.WriteLine("Enter id number of developer you would like to remove");

            DevTeam teamMember = new DevTeam();

            int IdNumber = int.Parse(Console.ReadLine());

           bool initialCount = _devTeamRepo.RemoveDevFromTeam(IdNumber);
            if (initialCount)
            {
                Console.WriteLine("Developer was successfully removed from team");
            }
            else
            {
                Console.WriteLine("Could not remove developer from team");
            }
        }

        //see method
        private void SeedDevList()
        {
            Developer devOne = new Developer("John Smith", 0, true);

          _devRepo.addNewDev(devOne);
        }

    }
}
