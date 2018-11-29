namespace FootballSimulationGameLibrary
{
    public class ClubStatistics
    {
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; private set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int MatchesDrew { get; set; }
        public int LeaguePosition { get; set; }

        public void UpdateGoalDifference()
        {
            this.GoalDifference = GoalsFor - GoalsAgainst;
        }
    }
}