using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_HW1.DLL.Modules
{
    public class PlayerGame
    {
        public int GameID { get; set; }
        public Game Game { get; set; }
        public int PlayerID { get; set; }
        public Player Player { get; set; }

        public int GoalsScored { get; set; }
    }
}
