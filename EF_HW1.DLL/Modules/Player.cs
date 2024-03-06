using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_HW1.DLL.Modules
{
    public class Player
    {
        public int ID {  get; set; }
        public string FullName {  get; set; }
        public int PlayerNumber {  get; set; }
        public string Position {  get; set; }

        public Team Team { get; set; }

        public List<PlayerGame> PlayerGames { get; set; }
    }
}
