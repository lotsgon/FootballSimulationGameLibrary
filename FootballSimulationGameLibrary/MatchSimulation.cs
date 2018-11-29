using System;

namespace FootballSimulationGameLibrary
{
    public static class MatchSimulation
    {
        public static void GetMatchResult(LeagueFixture fixture)
        {
            var matchScore = GetMatchScore(fixture);
            fixture.SetFixtureResult(matchScore.HomeGoals, matchScore.AwayGoals);

            SetFixtureResultRelatedStatistics(fixture);

            if (matchScore.HomeGoals > matchScore.AwayGoals)
            {
                fixture.HomeTeam.UpdateBoardHappiness(5);
                fixture.HomeTeam.UpdateMorale(1);
                fixture.AwayTeam.UpdateBoardHappiness(-3);
                fixture.AwayTeam.UpdateMorale(-1);
                return;
            }
            else if (matchScore.AwayGoals > matchScore.HomeGoals)
            {
                fixture.HomeTeam.UpdateBoardHappiness(-8);
                fixture.HomeTeam.UpdateMorale(-1);
                fixture.AwayTeam.UpdateBoardHappiness(6);
                fixture.AwayTeam.UpdateMorale(1);
                return;
            }

            fixture.HomeTeam.UpdateMorale(-3);
            fixture.AwayTeam.UpdateMorale(1);
        }

        private static MatchScore GetMatchScore(LeagueFixture fixture)
        {
            var homeClub = fixture.HomeTeam;
            var awayClub = fixture.AwayTeam;

            homeClub.UpdateMatchDayLineUp();
            awayClub.UpdateMatchDayLineUp();

            var matchScore = new MatchScore(0, 0);
            var rand = new Random(Guid.NewGuid().GetHashCode());

            var homeAdv = ((homeClub.OverallLineUpRating / 9.8f) + (homeClub.Manager.OverallRating / 9.8f) + (homeClub.Morale / 1.8f)) / 2.8f;
            var awayAdv = ((awayClub.OverallLineUpRating / 10.2f) + (awayClub.Manager.OverallRating / 10.2f) + (awayClub.Morale / 2.2f)) / 3.2f;

            var homeRate = (int)homeAdv;
            var awayRate = (int)awayAdv;

            if (homeRate > awayRate)
            {
                matchScore.HomeGoals += Math.Max((int)(Math.Floor((Math.Abs(rand.Next(0, Math.Max(homeRate + 2, 1)) - rand.Next(0, Math.Max(homeRate, 1)))) * (((rand.NextDouble() * ((0.1f + 0.8f) + 0.3f) + rand.NextDouble()))))), 0);
                matchScore.AwayGoals += Math.Max((int)(Math.Floor((Math.Abs(rand.Next(0, Math.Max(awayRate, 1)) - rand.Next(0, Math.Max(awayRate, 1)))) * (((rand.NextDouble() * ((0.1f + 0.5f) + 0.3f) + rand.NextDouble()))))), 0);
            }
            else if (awayRate > homeRate)
            {
                matchScore.HomeGoals += Math.Max((int)(Math.Floor((Math.Abs(rand.Next(0, Math.Max(homeRate, 1)) - rand.Next(0, Math.Max(homeRate, 1)))) * (((rand.NextDouble() * ((0.1f + 0.4f) + 0.3f) + rand.NextDouble()))))), 0);
                matchScore.AwayGoals += Math.Max((int)(Math.Floor((Math.Abs(rand.Next(0, Math.Max(awayRate, 1)) - rand.Next(0, Math.Max(awayRate, 1)))) * (((rand.NextDouble() * ((0.1f + 0.7f) + 0.3f) + rand.NextDouble()))))), 0);
            }                                                                                               
            else                                                                                            
            {                                                                                               
                matchScore.HomeGoals += Math.Max((int)(Math.Floor((Math.Abs(rand.Next(0, Math.Max(homeRate, 1)) - rand.Next(0, Math.Max(homeRate, 1)))) * (((rand.NextDouble() * ((0.1f + 0.6f) + 0.3f) + rand.NextDouble()))))), 0);
                matchScore.AwayGoals += Math.Max((int)(Math.Floor((Math.Abs(rand.Next(0, Math.Max(awayRate, 1)) - rand.Next(0, Math.Max(awayRate, 1)))) * (((rand.NextDouble() * ((0.1f + 0.6f) + 0.3f) + rand.NextDouble()))))), 0);
            }

            return matchScore;
        }

        private static void SetFixtureResultRelatedStatistics(LeagueFixture fixture)
        {
            var homeTeamStats = fixture.HomeTeam.Statistics;
            var awayTeamStats = fixture.AwayTeam.Statistics;

            homeTeamStats.MatchesPlayed += 1;
            homeTeamStats.GoalsFor += fixture.HomeGoals;
            homeTeamStats.GoalsAgainst += fixture.AwayGoals;
            homeTeamStats.UpdateGoalDifference();

            awayTeamStats.MatchesPlayed += 1;
            awayTeamStats.GoalsFor += fixture.AwayGoals;
            awayTeamStats.GoalsAgainst += fixture.HomeGoals;
            awayTeamStats.UpdateGoalDifference();

            if (fixture.HomeGoals > fixture.AwayGoals)
            {
                awayTeamStats.MatchesLost += 1;

                homeTeamStats.MatchesWon += 1;
                homeTeamStats.Points += 3;
            }
            else if (fixture.AwayGoals > fixture.HomeGoals)
            {
                homeTeamStats.MatchesLost += 1;

                awayTeamStats.MatchesWon += 1;
                awayTeamStats.Points += 3;
            }
            else
            {
                homeTeamStats.MatchesDrew += 1;
                homeTeamStats.Points += 1;

                awayTeamStats.MatchesDrew += 1;
                awayTeamStats.Points += 1;
            }
        }
    }
}
