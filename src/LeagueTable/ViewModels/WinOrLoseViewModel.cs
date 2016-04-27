using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueTable.ViewModels
{
    public class WinOrLoseViewModel
    {
        public string teamName { get; set;}
        public int playedGames { get; set; }
        public int points { get; set; }
        public int maxPoints { get; set; }
        public bool canWinLeague { get; set; }
        public bool canBeRelegated { get; set; }
        public bool areRelegated { get; set; }
        public int position { get; set; }
        public int availablePoints { get; set; }
    }
}
