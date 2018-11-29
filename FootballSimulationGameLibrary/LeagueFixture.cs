namespace FootballSimulationGameLibrary
{
    public class LeagueFixture
    {
        public FootballClub HomeTeam { get; private set; }
        public FootballClub AwayTeam { get; private set; }
        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }
        public int MatchRound { get; private set; }

        public LeagueFixture(FootballClub homeTeam, FootballClub awayTeam)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
        }

        public void SetFixtureResult(int homeGoals, int awayGoals)
        {
            this.HomeGoals = homeGoals;
            this.AwayGoals = awayGoals;
        }
    }
}