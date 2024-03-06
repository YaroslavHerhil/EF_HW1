using EF_HW1.DLL;
using EF_HW1.DLL.Modules;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EF_HW1
{
    public class Service
    {
        Repository<Team> _repositoryTeam;
        Repository<Player> _repositoryPlayer;
        Repository<Game> _repositoryGame;
        public Service() 
        { 
            _repositoryTeam = new Repository<Team>(); 
            _repositoryPlayer = new Repository<Player>(); 
            _repositoryGame = new Repository<Game>();
        }


        public void ShowData(List<Team> footballs)
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
        public void ShowData(List<Player> players)
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
        public void ShowData(List<Game> games)
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
                foreach (Player player in game.PlayerGames.Select(p => p.Player))
                {
                    Console.Write($"{player.ID}, ");
                }
            }
        }
        public void ShowData(Dictionary<string, string> goalsDelta)
        {
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
        }

        public void AllTeams()
        {
            var team_set = _repositoryTeam.GetEntity();
            var footballs = team_set.ToList();
            ShowData(footballs);
        }
        public void AllPlayers()
        {
            var player_set = _repositoryPlayer.GetEntity();
            var players = player_set.Include(p => p.Team).ToList();
            ShowData(players);
        }
        public void AllGames()
        {
            var game_set = _repositoryGame.GetEntity();
            var games = game_set.Include(g => g.Team1).Include(g => g.Team2).Include(gi => gi.PlayerGames).ToList();
            ShowData(games);
        }
        public void FindTeams()
        {
            string teamName = UserPrompt("Team name:");
            string teamRegion = UserPrompt("Team region:");

            var team_set = _repositoryTeam.GetEntity();
            var footballs = team_set.Where(f => f.TeamName.ToLower().Contains(teamName.ToLower()))
                            .Where(f => f.TeamRegion.ToLower().Contains(teamRegion.ToLower()))
                            .ToList();

            ShowData(footballs);
        }

        public void GameByDate()
        {
            DateTime date = GetDate();



            var game_set = _repositoryGame.GetEntity();
            var footballs = game_set.Where(f => f.Date.Equals(date))
                                    .Include(g => g.Team1).Include(g => g.Team2).Include(gi => gi.PlayerGames).ToList();
            ShowData(footballs);
        }
        public void GameByTeam()
        {
            Team team = GetTeam(UserPrompt("Team Name:"));
            var game_set = _repositoryGame.GetEntity();

            var footballs = game_set.Where(f => f.Team1.Equals(team) || f.Team2.Equals(team))
                                    .Include(g => g.Team1).Include(g => g.Team2).Include(gi => gi.PlayerGames).ToList();
            ShowData(footballs);

        }
        public void GoalsDelta()
        {
            var team_set = _repositoryTeam.GetEntity();

            var teams = team_set.ToList();
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var team in teams)
            {
                result.Add(team.TeamName, (team.Goals - team.MissedGoals).ToString());
            }
            ShowData(result);

        }
        public void GetTeamWithMaxGoals()
        {
            var team_set = _repositoryTeam.GetEntity();

            var footballs = team_set.Where(f => f.Goals == team_set.Max(g => g.Goals))
                                    .ToList();
            ShowData(footballs);
        }
        public void GetTeamWithMaxMissedGoals()
        {
            var team_set = _repositoryTeam.GetEntity();

            var footballs = team_set.Where(f => f.MissedGoals == team_set.Max(g => g.MissedGoals))
                                    .ToList();
            ShowData(footballs);
        }
        public void GetTeamWithMaxLoses()
        {
            var team_set = _repositoryTeam.GetEntity();

            var footballs = team_set.Where(f => f.MissedGoals == team_set.Max(g => g.Loses))
                                    .ToList();
            ShowData(footballs);
        }
        public void GetTeamWithMaxWins()
        {
            var team_set = _repositoryTeam.GetEntity();

            var footballs = team_set.Where(f => f.MissedGoals == team_set.Max(g => g.Wins))
                                    .ToList();
            ShowData(footballs);
        }
        public void GetTeamWithMaxDraws()
        {
            var team_set = _repositoryTeam.GetEntity();

            var footballs = team_set.Where(f => f.MissedGoals == team_set.Max(g => g.Draws))
                                    .ToList();
            ShowData(footballs);
        }

        public void PlayersByDate()
        {
            DateTime date = GetDate();

            var game_set = _repositoryGame.GetEntity();
            var players = game_set.Include(gi => gi.PlayerGames)
                                    .Where(g => g.Date.Equals(date))
                                    .SelectMany(gi => gi.PlayerGames.Select(p => p.Player))
                                    .ToList();
            ShowData(players);
        }


        public DateTime GetDate()
        {
            if (!DateTime.TryParse(UserPrompt("Enter the date"), out DateTime date))
            {
                Console.WriteLine("Invalid value");
                throw new Exception();
            }
            return date;
        }
        public Team GetTeam(string teamName)
        {
            return _repositoryTeam.GetEntity().Include(t => t.Players).FirstOrDefault(t => t.TeamName == teamName);
        }
        public Player GetPlayer(string name)
        {
            return _repositoryPlayer.GetEntity().Include(p => p.Team).FirstOrDefault(p => p.FullName == name);
        }

        public string UserPrompt(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public Team MapDataTeam()
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
        public Game MapDataGame()
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
            game.PlayerGames = MapPlayerGames(game);
            return game;
        }
        public List<PlayerGame> MapPlayerGames(Game game)
        {
            List<PlayerGame> playersGames = new List<PlayerGame>();

            bool gettingData = true;
            string pName;
            while (gettingData)
            {
                pName = UserPrompt("Name of a player who scored:");
                var player = GetPlayer(pName);
                if (player != null)
                {
                    int goals = int.Parse(UserPrompt("Goals scored:"));

                    var playerGame = new PlayerGame
                    {
                        GameID = game.ID,
                        PlayerID = player.ID,
                        GoalsScored = goals
                    };
                    playersGames.Add(playerGame);
                }
                else
                {
                    Console.WriteLine("Player not found");
                }

                if (playersGames.Count > 0 && UserPrompt("Continue?[Y=yes/Any=no]").ToLower() != "y")
                {
                    gettingData = false;
                }
            }


            return playersGames;
        }


        public void AddTeam()
        {
            Team new_team = MapDataTeam();
            if (GetTeam(new_team.TeamName) == null)
            {
                _repositoryTeam.AddEntity(new_team);
            }
            else
            {
                Console.WriteLine("Team already exists");
            }

        }
        public void AddGame()
        {
            Game newGame = MapDataGame();


            if (newGame == null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            _repositoryGame.AddEntity(newGame);
        }

        private Team ChangeTeam(Team team)
        {
            string change = UserPrompt("What would you like to change?\n\t1)Name\n\t2)Region\n\t3)Win count\n\t4)Lose count\n\t5)Draw count\n\t6)Goals\n\t7)Missed goals");
            switch (change)
            {
                case "1":
                    team.TeamName = UserPrompt("New team name:");
                    break;
                case "2":
                    team.TeamRegion = UserPrompt("New team region:");
                    break;
                case "3":
                    team.Wins = int.TryParse(UserPrompt("New team win count:"), out int wins) ? wins : team.Wins;
                    break;
                case "4":
                    team.Loses = int.TryParse(UserPrompt("New team lose count:"), out int loses) ? loses : team.Loses;
                    break;
                case "5":
                    team.Draws = int.TryParse(UserPrompt("New team draw count:"), out int draws) ? draws : team.Draws;
                    break;
                case "6":
                    team.Goals = int.TryParse(UserPrompt("New team goal count:"), out int goals) ? goals : team.Goals;
                    break;
                case "7":
                    team.MissedGoals = int.TryParse(UserPrompt("New team missed goal count:"), out int mgoals) ? mgoals : team.MissedGoals;
                    break;
                default: break;
            }
            return team;
        }

        public void UpdateTeam()
        {
            var updated_team = GetTeam(UserPrompt("Team Name:"));

            if (updated_team == null)
            {
                Console.WriteLine("Team not found");
                return;
            }

            updated_team = ChangeTeam(updated_team);
            _repositoryTeam.UpdateEntity(updated_team);

        }
        public void DeleteData()
        {
            var deletion_team = GetTeam(UserPrompt("Team Name:"));

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


            _repositoryTeam.RemoveEntity(deletion_team);
        }

    }
}


