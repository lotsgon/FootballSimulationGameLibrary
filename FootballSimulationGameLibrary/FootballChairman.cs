namespace FootballSimulationGameLibrary
{
    public class FootballChairman
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public int Age { get; private set; }
        public string Nationality { get; private set; }
        public int Happiness { get; private set; }
        public int OverallRating { get; private set; }
        public int PotentialRating { get; private set; }
        public FootballClub CurrentClub { get; private set; }
        public FootballClub PreviousClub { get; private set; }
        public ChairmanType Type { get; private set; }
        public long PersonalFortune { get; private set; }
        public int Reputation { get; private set; }
        public bool JustMoved { get; private set; }

        public FootballChairman(int ID, string firstName, string surname, int age, int happiness, int overallRating, int potentialRating, long personalFortune)
        {
            this.ID = ID;
            this.FirstName = firstName;
            this.Surname = surname;
            this.FullName = firstName + ' ' + surname;
            this.ShortName = firstName[0] + ". " + surname;
            this.Age = age;
            this.Happiness = happiness;
            this.OverallRating = overallRating;
            this.PotentialRating = potentialRating;
            this.PersonalFortune = personalFortune;
            this.Reputation = overallRating;
            this.JustMoved = false;
        }

        public void SetCurrentClub(FootballClub club)
        {
            this.CurrentClub = club;
        }

        public void UpdateCurrentClub(FootballClub newClub)
        {
            this.PreviousClub = this.CurrentClub;
            this.CurrentClub = newClub;
            this.JustMoved = true;
            this.Happiness = 100;
        }

        public void UpdatePersonalFinance(long amount)
        {
            this.PersonalFortune += amount;
        }

        private ChairmanType GetChairmanType(long fortune)
        {
            if (fortune > 1000000000)
            {
                return ChairmanType.Tycoon;
            }
            else if (fortune > 100000000)
            {
                return ChairmanType.Consortium;
            }

            return ChairmanType.FansConsortium;
        }
    }
}