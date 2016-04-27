using LeagueTable.Models;
using LeagueTable.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueTable.Calculations
{
    public static class Calculate
    {
        public static List<WinOrLoseViewModel> whoCanWinOrLose(LogData Log)
        {
            List<WinOrLoseViewModel> ListWLVM = new List<WinOrLoseViewModel>();
            int leaderPoints = Log.standing[0].points;
            int relegationDangerPoints = 0;
            int relegationSafetyPoints = Log.standing[16].points;
            int maxGames = 38;

            for (int i = 19; i >= 17; i--)
            {
                int dangerPoints = Log.standing[i].points + ((maxGames - Log.standing[i].playedGames) * 3);
                if(dangerPoints >= relegationDangerPoints)
                {
                    relegationDangerPoints = dangerPoints;
                }
            }
            
            foreach (var team in Log.standing)
            {
                int position = team.position;
                int availablePoints = (maxGames - team.playedGames) * 3;
                int maxPoints = team.points + availablePoints;
                bool canStillWin = false;
                bool canStillBeRelegated = false;
                bool areRelegated = false;

                if (maxPoints >= leaderPoints)
                {
                    canStillWin = true;                   
                }
                
                if(relegationDangerPoints >= team.points)
                {
                    canStillBeRelegated = true;
                }

                if (maxPoints < relegationSafetyPoints)
                {
                    areRelegated = true;
                }

                WinOrLoseViewModel WLVM = new WinOrLoseViewModel {
                    teamName = team.teamName,
                    playedGames = team.playedGames,
                    canBeRelegated = canStillBeRelegated,
                    canWinLeague = canStillWin,
                    position = team.position,
                    maxPoints = maxPoints,
                    points = team.points,
                    areRelegated = areRelegated,
                    availablePoints = availablePoints               
                };

                ListWLVM.Add(WLVM);
            }

            return ListWLVM;
        }
    }
}
