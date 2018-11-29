using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballSimulationGameLibrary
{
    public static class TransferManagerSimulation
    {
        public static void SimulateManagerTransfers(List<FootballClub> clubList, List<FootballManager> managerList)
        {
            var managerChangeList = clubList.Where(x => x.ID != 0 && x.BoardHappiness < 40);

            if (managerChangeList.FirstOrDefault() == null)
            {
                return;
            }

            foreach (FootballClub club in managerChangeList)
            {
                var rand = new Random().Next(0, 8);

                for (int i = 0; i < rand; i++)
                {
                    if (ManagerChange(club, managerList))
                    {


                        break;
                    }
                }
            }
        }

        private static bool ManagerChange(FootballClub club, List<FootballManager> managerList)
        {
            var value = club.Value;
            var clubRep = (club.Reputation / 100) + 5;

            var rand = new Random().Next(0, managerList.Count - 1);
            FootballManager targetManager;

            try
            {
                targetManager = managerList.Where(x => x.CurrentClub == null && x.OverallRating - 10 < clubRep && !x.JustMoved).ElementAtOrDefault(rand);
            }
            catch (NullReferenceException e)
            {
                return false;
            }

            if (targetManager == null)
            {
                return false;
            }

            managerList.Add(club.Manager);
            club.UpdateReputation(-club.Manager.Reputation);
            club.Manager.UpdateCurrentClub(null);

            targetManager.UpdateCurrentClub(club);
            club.UpdateReputation(targetManager.Reputation);
            managerList.Remove(targetManager);

            club.UpdateManager(targetManager);

            return true;
        }

        public static List<FootballManager> GetManagerChanges(List<FootballManager> managerList)
        {
            try
            {
                return managerList.Where(x => x.JustMoved).ToList();
            }
            catch (NullReferenceException e)
            {
                return new List<FootballManager>();
            }
        }
    }
}