using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_HW1.DLL.Modules
{
    public class Team
    {
        public int ID { get; set; }
        public string TeamName {  get; set; }
        public string TeamRegion {  get; set; }
        public int Wins {  get; set; }
        public int Loses {  get; set; }
        public int Draws {  get; set; }
        public int? Goals { get; set; }
        public int? MissedGoals { get; set; }
        public List<Player> Players { get; set; }

    }
}
