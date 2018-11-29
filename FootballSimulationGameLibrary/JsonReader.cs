using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FootballSimulationGameLibrary
{
    public static class JsonReader
    {
        public static List<FootballPlayer> ReadJsonPlayersFile()
        {
            return JsonConvert.DeserializeObject<List<FootballPlayer>>(File.ReadAllText("C:/GitDev/JsonData/Players.json"));
        }

        public static List<FootballManager> ReadJsonManagersFile()
        {
            return JsonConvert.DeserializeObject<List<FootballManager>>(File.ReadAllText("C:/GitDev/JsonData/Managers.json"));
        }

        public static List<FootballChairman> ReadJsonChairmenFile()
        {
            return JsonConvert.DeserializeObject<List<FootballChairman>>(File.ReadAllText("C:/GitDev/JsonData/Chairmen.json"));
        }

        public static FootballLeague ReadJsonLeaguesFile()
        {
            return JsonConvert.DeserializeObject<FootballLeague>(File.ReadAllText("C:/GitDev/JsonData/EnglishPremierLeague.json"));
        }

        public static List<FootballClub> ReadJsonClubsFile()
        {
            var clubList = JsonConvert.DeserializeObject<List<FootballClub>>(File.ReadAllText("C:/GitDev/JsonData/OtherClubsWithSquads.json"));
            return clubList;
        }
    }
}

