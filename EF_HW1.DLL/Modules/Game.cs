using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_HW1.DLL.Modules
{
    public class Game
    {
        public int ID { get; set; }

        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public int GoalsTeam1 { get; set; }
        public int GoalsTeam2 { get; set; }

        public List<Player> PlayerGoalInfo {  get; set; }
        public DateTime Date { get; set; }
    }
}
