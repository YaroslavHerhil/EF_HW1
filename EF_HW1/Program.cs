using EF_HW1.DLL;
using EF_HW1.DLL.Modules;

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
                Console.WriteLine("Hello!\n\t1)Show list of teams\n\t2)Add a team\n\t0)Exit");
                string responce = Console.ReadLine();
                switch (responce)
                {
                    case "1":
                        ShowData();
                        Console.ReadKey();
                        break;
                    case "2":
                        AddData();
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

        private static void ShowData()
        {
            using (var context = new Context())
            {
                var footballs = context.Footballs;
                Console.WriteLine("{7, 4}│{0,-30}│{1,-30}|{2,-5}│{3, -5}│{4, -5}│{5, -10}│{6, -10}",
                                          "Team Name",
                                          "Team Region",
                                          "Wins",
                                          "Loses",
                                          "Draws",
                                          "Goals",
                                          "Missed goals",
                                          "Id");
                Console.WriteLine("────┼──────────────────────────────┼──────────────────────────────┼─────┼─────┼─────┼──────────┼──────────");

                foreach (SpanishFootball foot in footballs)
                {



                    Console.WriteLine("{7, 3})│{0,-30}│{1,-30}│{2,-5}│{3, -5}│{4, -5}│{5, -10}│{6, -10}",
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
                context.Footballs.Add(MapData());
                context.SaveChanges();
            }
        }

    }
}
