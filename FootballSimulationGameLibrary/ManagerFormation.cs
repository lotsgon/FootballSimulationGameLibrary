using System.Collections.Generic;

namespace FootballSimulationGameLibrary
{
    public class ManagerFormation
    {
        public string Name { get; private set; }
        public int Goal { get; private set; }
        public int Defence { get; private set; }
        public int Midfield { get; private set; }
        public int Attack { get; private set; }

        public ManagerFormation(string name, int goal, int defence, int midfield, int attack)
        {
            this.Name = name;
            this.Goal = goal;
            this.Defence = defence;
            this.Midfield = midfield;
            this.Attack = attack;
        }
    }
}
