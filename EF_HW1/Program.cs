using EF_HW1.DLL;
using EF_HW1.DLL.Modules;
using Microsoft.EntityFrameworkCore;

namespace EF_HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Spanish Football Manager 20XX\n\t1)Team menu\n\t2)Player menu\n\t3)Games menu\n\t0)Exit");
                string responce = Console.ReadLine();
                switch (responce)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Team menu\n\t1)Show list of teams\n\t2)Find a team\n\t3)Team with max wins\n\t4)Team with max loses\n\t5)Team with max draws\n\t6)Team with max goals\n\t7)Team with max missed goals\n\ta)Add a new team\n\tu)Update team info\n\td)Delete a team\n\t0)Back");
                        responce = Console.ReadLine();
                        switch (responce)
                        {
                            case "1":
                                ShowData(AllTeams());
                                Console.ReadKey();
                                break;
                            case "2":
                                Console.WriteLine("Input team information(you can leave some fields empty)");
                                Console.WriteLine("Team name:");
                                string teamName = Console.ReadLine();
                                Console.WriteLine("Team region:");
                                string teamRegion = Console.ReadLine();
                                ShowData(FindTeams(teamName, teamRegion));
                                Console.ReadKey();
                                break;
                            case "3":
                                ShowData(GetTeamWithMaxWins());
                                Console.ReadKey();
                                break;
                            case "4":
                                ShowData(GetTeamWithMaxLoses());
                                Console.ReadKey();
                                break;
                            case "5":
                                ShowData(GetTeamWithMaxDraws());
                                Console.ReadKey();
                                break;
                            case "6":
                                ShowData(GetTeamWithMaxGoals());
                                Console.ReadKey();
                                break;
                            case "7":
                                ShowData(GetTeamWithMaxMissedGoals());
                                Console.ReadKey();
                                break;
                            case "8":
                                var goalsDelta = GoalsDelta();
                                Console.WriteLine("{0, -20}│{1,-10}",
                                          "Team Name",
                                          "Goal delta"
                                        );
                                Console.WriteLine($"{new string('─', 20)}┼{new string('─', 10)}");
                                foreach (var goal in goalsDelta)
                                {
                                    Console.WriteLine("{0, -20}│{1,-20}",
                                          goal.Key,
                                          goal.Value
                                        );
                                }
                                Console.ReadKey();
                                break;
                            case "a":
                                AddTeam();
                                Console.ReadKey();
                                break;
                            case "u":
                                UpdateData();
                                Console.ReadKey();
                                break;
                            case "d":
                                DeleteData();
                                Console.ReadKey();
                                break;
                            case "0":
                                Console.WriteLine($"Goodbye!");
                                exit = true;
                                break;
                            default: break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Player menu\n\t1)Show list of all players\n\t0)Back");
                        responce = Console.ReadLine();
                        switch (responce)
                        {
                            case "1":
                                ShowData(AllPlayers());
                                Console.ReadKey();
                                break;
                            case "2":
                                if (DateTime.TryParse(UserPrompt("Enter the date of a game"), out DateTime date))
                                {
                                    ShowData(PlayersByDate(date));

                                }
                                else
                                {
                                    Console.WriteLine("Invalid value");
                                }
                                Console.ReadKey();
                                break;
                            default: break;
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Games menu\n\t1)Show list of all games\n\t0)Back");
                        responce = Console.ReadLine();
                        switch (responce)
                        {
                            case "1":
                                ShowData(AllGames());
                                Console.ReadKey();
                                break;
                            case "2":
                                if (DateTime.TryParse(UserPrompt("Enter the date of a game"), out DateTime date))
                                {
                                    ShowData(GameByDate(date));

                                }
                                else
                                {
                                    Console.WriteLine("Invalid value");
                                }
                                Console.ReadKey();
                                break;
                            case "3":
                                ShowData(GameByTeam(GetTeam(UserPrompt("Enter team name:"))));
                                Console.ReadKey();
                                break;

                            case "4":
                                AddGame();
                                Console.ReadKey();
                                break;
                            default: break;
                        }
                        break;
                }


            }
        }

        private static void ShowData(List<Team> footballs)
        {

            Console.WriteLine("{7, 4}│{0,-30}│{1,-30}|{2,-5}│{3, -5}│{4, -5}│{5, -10}│{6, -10}",
                                      "Team Name",
                                      "Team Region",
                                      "Wins",
                                      "Loses",
                                      "Draws",
                                      "Goals",
                                      "Missed goals",
                                      "Id");
            Console.WriteLine($"{new string('─', 4)}┼{new string('─', 30)}┼{new string('─', 30)}┼{new string('─', 5)}┼{new string('─', 5)}┼{new string('─', 5)}┼{new string('─', 10)}┼{new string('─', 10)}");

            foreach (Team foot in footballs)
            {
                Console.Write("{7, 3})│{0,-30}│{1,-30}│{2,-5}│{3, -5}│{4, -5}│{5, -10}│{6, -10}\n",
                                      foot.TeamName,
                                      foot.TeamRegion,
                                      foot.Wins,
                                      foot.Loses,
                                      foot.Draws,
                                      foot.Goals == null ? "No Data" : foot.Goals.ToString(),
                                      foot.MissedGoals == null ? "No Data" : foot.MissedGoals.ToString(),
                                      foot.ID);

            }
        }
        private static void ShowData(List<Player> players)
        {

            Console.WriteLine("{4, 4}│{0,-40}│{1,-4}│{2, -25}│{3, -30}",
                                      "Player Name",
                                      "Num.",
                                      "Position",
                                      "Team",
                                      "Id");
            Console.WriteLine($"{new string('─', 4)}┼{new string('─', 40)}┼{new string('─', 4)}┼{new string('─', 25)}┼{new string('─', 30)}");

            foreach (Player player in players)
            {


                Console.Write("{4, 3})│{0,-40}│{1,-4}│{2,-25}│{3, -30}\n",
                                      player.FullName,
                                      player.PlayerNumber,
                                      player.Position,
                                      player.Team.TeamName,
                                      player.ID);
            }
        }
        private static void ShowData(List<Game> games)
        {

            Console.Write("\n{6, 3})│{0,-25}│{1,-25}│{2,-10}│{3, -10}│{4, -10}│{5}",
                                      "Team 1",
                                      "Team 2",
                                      "T1 Goals",
                                      "T2 Goals",
                                      "Date",
                                      "Scored players(IDs)",
                                      "Id");
            Console.Write($"\n{new string('─', 4)}┼{new string('─', 25)}┼{new string('─', 25)}┼{new string('─', 10)}┼{new string('─', 10)}┼{new string('─', 10)}┼{new string('─', 15)}");

            foreach (Game game in games)
            {
                Console.Write("\n{5, 3})│{0,-25}│{1,-25}│{2,-10}│{3, -10}│{4, -10}│",
                                      game.Team1.TeamName,
                                      game.Team2.TeamName,
                                      game.GoalsTeam1,
                                      game.GoalsTeam2,
                                      game.Date.ToShortDateString(),
                                      game.ID);
                foreach (Player player in game.PlayerGoalInfo)
                {
                    Console.Write($"{player.ID}, ");
                }
            }
        }




        private static List<Team> AllTeams()
        {
            using (var context = new Context())
            {
                return context.Team.ToList();
            }
        }
        private static List<Player> AllPlayers()
        {
            using (var context = new Context())
            {
                return context.Player.Include(p => p.Team).ToList();
            }
        }
        private static List<Game> AllGames()
        {
            using (var context = new Context())
            {
                return context.Game.Include(g => g.Team1).Include(g => g.Team2).Include(gi => gi.PlayerGoalInfo).ToList();
            }
        }

        private static List<Team> FindTeams(string teamName, string teamRegion)
        {
            using (var context = new Context())
            {
                var footballs = context.Team
                                       .Where(f => f.TeamName.ToLower().Contains(teamName.ToLower()))
                                       .Where(f => f.TeamRegion.ToLower().Contains(teamRegion.ToLower()))
                                       .ToList();
                return footballs;
            }
        }
        private static List<Game> GameByDate(DateTime date)
        {
            using (var context = new Context())
            {
                var footballs = context.Game
                                       .Where(f => f.Date.Equals(date))
                                       .Include(g => g.Team1).Include(g => g.Team2).Include(gi => gi.PlayerGoalInfo).ToList();
                return footballs;
            }
        }
        private static List<Game> GameByTeam(Team team)
        {
            using (var context = new Context())
            {
                var footballs = context.Game
                                       .Where(f => f.Team1.Equals(team) || f.Team2.Equals(team))
                                       .Include(g => g.Team1).Include(g => g.Team2).Include(gi => gi.PlayerGoalInfo).ToList();
                return footballs;
            }
        }
        private static Dictionary<string, string> GoalsDelta()
        {
            using (var context = new Context())
            {
                var teams = context.Team.ToList();
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (var team in teams)
                {
                    result.Add(team.TeamName, (team.Goals - team.MissedGoals).ToString());
                }
                return result;
            }
        }


        private static List<Team> GetTeamWithMaxGoals()
        {
            using (var context = new Context())
            {
                var footballs = context.Team
                                       .Where(f => f.Goals == context.Team.Max(g => g.Goals))
                                       .ToList();
                return footballs;
            }
        }
        private static List<Team> GetTeamWithMaxMissedGoals()
        {
            using (var context = new Context())
            {
                var footballs = context.Team
                                       .Where(f => f.MissedGoals == context.Team.Max(g => g.MissedGoals))
                                       .ToList();
                return footballs;
            }
        }
        private static List<Team> GetTeamWithMaxLoses()
        {
            using (var context = new Context())
            {
                var footballs = context.Team
                                       .Where(f => f.Loses == context.Team.Max(g => g.Loses))
                                       .ToList();
                return footballs;
            }
        }
        private static List<Team> GetTeamWithMaxWins()
        {
            using (var context = new Context())
            {
                var footballs = context.Team
                                       .Where(f => f.Wins == context.Team.Max(g => g.Wins))
                                       .ToList();
                return footballs;
            }
        }
        private static List<Team> GetTeamWithMaxDraws()
        {
            using (var context = new Context())
            {
                var footballs = context.Team
                                       .Where(f => f.Draws == context.Team.Max(g => g.Draws))
                                       .ToList();
                return footballs;
            }
        }

        private static List<Player> PlayersByDate(DateTime date)
        {
            using (var context = new Context())
            {
                var players = context.Game
                                       .Include(gi => gi.PlayerGoalInfo).ThenInclude(p => p.Team)
                                       .Where(g => g.Date.Equals(date))
                                       .SelectMany(gi => gi.PlayerGoalInfo)
                                       .ToList();
                return players;
            }
        }

        private static Team GetTeam(string teamName)
        {
            using (var context = new Context())
            {
                return context.Team.Include(t => t.Players).FirstOrDefault(t => t.TeamName == teamName);
            }
        }

        private static Player GetPlayer(string name)
        {
            using (var context = new Context())
            {
                return context.Player.Include(p => p.Team).FirstOrDefault(p => p.FullName == name);
            }
        }


        private static string UserPrompt(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        private static Team MapData()
        {
            Team foot = new Team()
            {
                TeamName = UserPrompt("Team name:"),

                TeamRegion = UserPrompt("Team region:"),

                Wins = int.TryParse(UserPrompt("Wins: "), out int wins) ? wins : 0,

                Loses = int.TryParse(UserPrompt("Loses: "), out int loses) ? loses : 0,

                Draws = int.TryParse(UserPrompt("Draws: "), out int draws) ? draws : 0,

                Goals = int.TryParse(UserPrompt("Goals: "), out int goals) ? goals : null,

                MissedGoals = int.TryParse(UserPrompt("Missed goals: "), out int mGoals) ? mGoals : null,
            };

            return foot;
        }
        private static Game MapDataGame()
        {
            Game game = new Game();

            Team team1 = GetTeam(UserPrompt("Team 1 name:"));
            if (team1 == null)
            {
                return null;
            }
            Team team2 = GetTeam(UserPrompt("Team 2 name:"));
            if (team2 == null)
            {
                return null;
            }

            game.Team1 = team1;
            game.Team2 = team2;

            if (!int.TryParse(UserPrompt("Team 1 goals:"), out int goals1) || !int.TryParse(UserPrompt("Team 2 goals:"), out int goals2))
            {
                return null;
            }
            game.GoalsTeam1 = goals1;
            game.GoalsTeam2 = goals2;

            if (!DateTime.TryParse(UserPrompt("Date of the game"), out DateTime date))
            {
                return null;
            }
            game.Date = date;
            game.PlayerGoalInfo = MapGGP(game);
            return game;
        }

        private static List<Player> MapGGP(Game game)
        {
            List<Player> scoredPlayers = new List<Player>();

            bool gettingData = true;
            string pName;
            while (gettingData)
            {
                pName = UserPrompt("Name of a player who scored");
                var player = GetPlayer(pName);
                if (player != null)
                {
                   scoredPlayers.Add(player);
                }
                else
                {
                    Console.WriteLine("Player not found");
                }

                if (scoredPlayers.Count > 0 && UserPrompt("Continue?[Y=yes/Any=no]").ToLower() != "y")
                {
                    gettingData = false;
                }
            }


            return scoredPlayers;
        }


        private static void AddTeam()
        {
            using (var context = new Context())
            {
                Team new_team = MapData();
                var teams = context.Team.ToList();
                if (!teams.Where(t => t.TeamName == new_team.TeamName).ToList().Any())
                {
                    context.Team.Add(new_team);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Team already exists");
                }

            }
        }
        private static void AddGame()
        {
            using (var context = new Context())
            {
                Game newGame = MapDataGame();


                if (newGame == null)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                context.Team.Attach(newGame.Team1);
                context.Team.Attach(newGame.Team2);
                context.Game.Add(newGame);
                context.SaveChanges();

            }
        }
        private static void UpdateData()
        {
            using (var context = new Context())
            {
                string team_name = UserPrompt("Team Name:");
                string team_region = UserPrompt("Team Region:");
                var teams = context.Team.ToList();
                var updated_team = teams.FirstOrDefault(t => t.TeamName == team_name && t.TeamRegion == team_region);
                if (updated_team == null)
                {
                    Console.WriteLine("Team not found");
                    return;
                }

                string change = UserPrompt("What would you like to change?\n\t1)Name\n\t2)Region\n\t3)Win count\n\t4)Lose count\n\t5)Draw count\n\t6)Goals\n\t7)Missed goals");
                switch (change)
                {
                    case "1":
                        updated_team.TeamName = UserPrompt("New team name:");
                        break;
                    case "2":
                        updated_team.TeamRegion = UserPrompt("New team region:");
                        break;
                    case "3":
                        updated_team.Wins = int.TryParse(UserPrompt("New team win count:"), out int wins) ? wins : updated_team.Wins;
                        break;
                    case "4":
                        updated_team.Loses = int.TryParse(UserPrompt("New team lose count:"), out int loses) ? loses : updated_team.Loses;
                        break;
                    case "5":
                        updated_team.Draws = int.TryParse(UserPrompt("New team draw count:"), out int draws) ? draws : updated_team.Draws;
                        break;
                    case "6":
                        updated_team.Goals = int.TryParse(UserPrompt("New team goal count:"), out int goals) ? goals : updated_team.Goals;
                        break;
                    case "7":
                        updated_team.MissedGoals = int.TryParse(UserPrompt("New team missed goal count:"), out int mgoals) ? mgoals : updated_team.MissedGoals;
                        break;
                    default: break;
                }

                context.Team.Update(updated_team);
                context.SaveChanges();
                Console.WriteLine("Team info updated");

            }
        }
        private static void DeleteData()
        {
            using (var context = new Context())
            {
                string team_name = UserPrompt("Team Name:");
                string team_region = UserPrompt("Team Region:");
                var teams = context.Team.ToList();
                var deletion_team = teams.FirstOrDefault(t => t.TeamName == team_name && t.TeamRegion == team_region);

                if (deletion_team == null)
                {
                    Console.WriteLine("Team not found");
                    return;
                }

                string decision = UserPrompt("Would you like to delete this team? This decision is final(Yes = delete)");

                if (decision.ToLower() != "yes")
                {
                    Console.WriteLine("Okay then.");
                    return;
                }


                context.Team.Remove(deletion_team);
                context.SaveChanges();
                Console.WriteLine("Team deleted.");

            }
        }

    }
}
