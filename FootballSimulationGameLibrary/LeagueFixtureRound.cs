using System.Collections.Generic;

namespace FootballSimulationGameLibrary
{
    public class LeagueFixtureRound
    {
        public List<LeagueFixture> LeagueRoundFixtures { get; private set; }
        public int LeagueRound { get; private set; }
        public int SeasonWeek { get; private set; }

        public LeagueFixtureRound()
        {
            this.LeagueRoundFixtures = new List<LeagueFixture>();
            this.LeagueRound = 0;
            this.SeasonWeek = 0;
        }

        public LeagueFixtureRound(List<LeagueFixture> leagueRoundFixtures, int leagueRound, int seasonWeek)
        {
            this.LeagueRoundFixtures = leagueRoundFixtures;
            this.LeagueRound = leagueRound;
            this.SeasonWeek = seasonWeek;
        }

        public void SetRoundAndWeek(int i)
        {
            this.LeagueRound = i;
            this.SeasonWeek = i + 6;
        }
    }
}
