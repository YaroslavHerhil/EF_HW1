
using Azure;

namespace EF_HW1
{
    public class Menu
    {
        Service _service;

        public Menu()
        {
            _service = new Service();
        }

        public void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Spanish Football Manager 20XX\n\t1)Team menu\n\t2)Player menu\n\t3)Games menu\n\t0)Exit");
                string responce = Console.ReadLine();
                switch (responce)
                {
                    case "1":
                        TeamMenu();
                        break;
                    case "2":
                        PlayerMenu();
                        break;
                    case "3":
                        GameMenu();
                        break;
                    case "0":
                        exit = true;
                        break;
                }
            }
        }

        public void TeamMenu()
        {
            Console.Clear();
            Console.WriteLine("Team menu\n\t1)Show list of teams\n\t2)Find a team\n\t3)Team with max wins\n\t4)Team with max loses\n\t5)Team with max draws\n\t6)Team with max goals\n\t7)Team with max missed goals\n\ta)Add a new team\n\tu)Update team info\n\td)Delete a team");
            string responce = Console.ReadLine();
            switch (responce)
            {
                case "1":
                    _service.AllTeams();
                    break;
                case "2":

                    _service.FindTeams();
                    break;
                case "3":
                    _service.GetTeamWithMaxWins();
                    break;
                case "4":
                    _service.GetTeamWithMaxLoses();
                    break;
                case "5":
                    _service.GetTeamWithMaxDraws();
                    break;
                case "6":
                    _service.GetTeamWithMaxGoals();
                    break;
                case "7":
                    _service.GetTeamWithMaxMissedGoals();
                    break;
                case "8":
                    _service.GoalsDelta();
                    break;
                case "a":
                    _service.AddTeam();
                    break;
                case "u":
                    _service.UpdateTeam();
                    break;
                case "d":
                    _service.DeleteData();
                    break;
                default: break;
            }
        }

        public void PlayerMenu()
        {
            Console.Clear();
            Console.WriteLine("Player menu\n\t1)Show list of all players\n\t0)Back");
            string responce = Console.ReadLine();
            switch (responce)
            {
                case "1":
                    _service.AllPlayers();
                    break;
                case "2":
                    _service.PlayersByDate();

                    break;
                default: break;
            }

        }

        public void GameMenu()
        {
            Console.Clear();
            Console.WriteLine("Games menu\n\t1)Show list of all games\n\t0)Back");
            string responce = Console.ReadLine();
            switch (responce)
            {
                case "1":
                    _service.AllGames();
                    break;
                case "2":
                    _service.GameByDate();
                    break;
                case "3":
                    _service.GameByTeam();
                    break;

                case "4":
                    _service.AddGame();
                    break;
                default: break;
            }
        }

    }
}
