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
                Console.WriteLine("Spanish Football Manager 20XX\n\t1)Show list of teams\n\t2)Find a team\n\t3)Team with max wins\n\t4)Team with max loses\n\t5)Team with max draws\n\t6)Team with max goals\n\t7)Team with max missed goals\n\ta)Add a new team\n\tu)Update team info\n\td)Delete a team\n\t0)Exit");
                string responce = Console.ReadLine();
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
                    case "a":
                        AddData();
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
            }
        }

        private static void ShowData(List<SpanishFootball> footballs)
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

                foreach (SpanishFootball foot in footballs)
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
        private static List<SpanishFootball> AllTeams()
        {
            using (var context = new Context())
            {
                return context.Footballs.ToList();
            }
        }

        private static List<SpanishFootball> FindTeams(string teamName, string teamRegion)
        {
            using (var context = new Context())
            {
                var footballs = context.Footballs
                                       .Where(f => f.TeamName.ToLower().Contains(teamName.ToLower()))
                                       .Where(f => f.TeamRegion.ToLower().Contains(teamRegion.ToLower()))
                                       .ToList();
                return footballs;
            }
        }



        private static List<SpanishFootball> GetTeamWithMaxGoals()
        {
            using (var context = new Context())
            {
                var footballs = context.Footballs
                                       .Where(f => f.Goals == context.Footballs.Max(g => g.Goals))
                                       .ToList();
                return footballs;
            }
        }
        private static List<SpanishFootball> GetTeamWithMaxMissedGoals()
        {
            using (var context = new Context())
            {
                var footballs = context.Footballs
                                       .Where(f => f.MissedGoals == context.Footballs.Max(g => g.MissedGoals))
                                       .ToList();
                return footballs;
            }
        }
        private static List<SpanishFootball> GetTeamWithMaxLoses()
        {
            using (var context = new Context())
            {
                var footballs = context.Footballs
                                       .Where(f => f.Loses == context.Footballs.Max(g => g.Loses))
                                       .ToList();
                return footballs;
            }
        }
        private static List<SpanishFootball> GetTeamWithMaxWins()
        {
            using (var context = new Context())
            {
                var footballs = context.Footballs
                                       .Where(f => f.Wins == context.Footballs.Max(g => g.Wins))
                                       .ToList();
                return footballs;
            }
        }
        private static List<SpanishFootball> GetTeamWithMaxDraws()
        {
            using (var context = new Context())
            {
                var footballs = context.Footballs
                                       .Where(f => f.Draws == context.Footballs.Max(g => g.Draws))
                                       .ToList();
                return footballs;
            }
        }



        private static string UserPrompt(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        private static SpanishFootball MapData()
        {
            SpanishFootball foot = new SpanishFootball()
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


        private static void AddData()
        {
            using (var context = new Context())
            {
                SpanishFootball new_team = MapData();
                var teams = context.Footballs.ToList();
                if(!teams.Where(t => t.TeamName == new_team.TeamName && t.TeamRegion == new_team.TeamRegion).ToList().Any())
                {
                    context.Footballs.Add(new_team);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Team already exists");
                }
                    
            }
        }
        private static void UpdateData()
        {
            using (var context = new Context())
            {
                string team_name = UserPrompt("Team Name:");
                string team_region = UserPrompt("Team Region:");
                var teams = context.Footballs.ToList();
                var updated_team = teams.FirstOrDefault(t => t.TeamName == team_name && t.TeamRegion == team_region);
                if(updated_team == null) 
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

                context.Footballs.Update(updated_team);
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
                var teams = context.Footballs.ToList();
                var deletion_team = teams.FirstOrDefault(t => t.TeamName == team_name && t.TeamRegion == team_region);

                if (deletion_team == null)
                {
                    Console.WriteLine("Team not found");
                    return;
                }

                string decision = UserPrompt("Would you like to delete this team? This decision is final(Yes = delete)");

                if(decision.ToLower() != "yes")
                {
                    Console.WriteLine("Okay then.");
                    return;
                }
                

                context.Footballs.Remove(deletion_team);
                context.SaveChanges();
                Console.WriteLine("Team deleted.");

            }
        }

    }
}
