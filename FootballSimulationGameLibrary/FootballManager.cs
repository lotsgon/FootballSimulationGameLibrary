namespace FootballSimulationGameLibrary
{
    public class FootballManager
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public int Age { get; private set; }
        public string Nationality { get; private set; }
        public ManagerFormation Formation { get; private set; }
        public int OverallRating { get; private set; }
        public int PotentialRating { get; private set; }
        public FootballClub CurrentClub { get; private set; }
        public FootballClub PreviousClub { get; private set; }
        public int Wage { get; private set; }
        public int Reputation { get; private set; }
        public bool JustMoved { get; private set; }

        public FootballManager(int ID, string firstName, string surname, int age, ManagerFormation formation, int overallRating, int potentialRating, int wage)
        {
            this.ID = ID;
            this.FirstName = firstName;
            this.Surname = surname;
            this.FullName = firstName + ' ' + surname;
            this.ShortName = firstName[0] + ". " + surname;
            this.Age = age;
            this.Formation = formation;
            this.OverallRating = overallRating;
            this.PotentialRating = potentialRating;
            this.Wage = wage;
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
        }

        public void UpdateJustMoved()
        {
            this.JustMoved = !this.JustMoved;
        }
    }
}
