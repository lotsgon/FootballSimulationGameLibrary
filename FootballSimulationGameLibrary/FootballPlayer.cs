namespace FootballSimulationGameLibrary
{
    public class FootballPlayer
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public int Age { get; private set; }
        public string Nationality { get; private set; }
        public PlayerPosition Position { get; private set; }
        public int OverallRating { get; private set; }
        public int PotentialRating { get; private set; }
        public FootballClub CurrentClub { get; private set; }
        public FootballClub PreviousClub { get; private set; }
        public int Value { get; private set; }
        public int Wage { get; private set; }
        public int Reputation { get; private set; }
        public bool JustMoved { get; private set; }

        public FootballPlayer(int ID, string firstName, string surname, int age, PlayerPosition position, int overallRating, int potentialRating, int value, int wage)
        {
            this.ID = ID;
            this.FirstName = firstName;
            this.Surname = surname;
            this.FullName = firstName + ' ' + surname;
            this.ShortName = firstName[0] + ". " + surname;
            this.Age = age;
            this.Position = position;
            this.OverallRating = overallRating;
            this.PotentialRating = potentialRating;
            this.Value = value;
            this.Wage = wage;
            this.Reputation = overallRating;
            this.JustMoved = false;
        }

        public void UpdateCurrentClub(FootballClub newClub)
        {
            this.PreviousClub = this.CurrentClub;
            this.CurrentClub = newClub;
            this.UpdateJustMoved();
        }

        public void SetCurrentClub(FootballClub club)
        {
            this.CurrentClub = club;
        }

        public void UpdateJustMoved()
        {
            this.JustMoved = !this.JustMoved;
        }
    }
}