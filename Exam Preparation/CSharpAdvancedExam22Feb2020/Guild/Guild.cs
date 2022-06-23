using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {

        List<Player> roster;
        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Roster.Count;

        public Guild(string name, int capacity)
        {
            Roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public void AddPlayer(Player player)
        {
            if (Capacity > 0)
            {
                Roster.Add(player);
                Capacity--;
            }
        }

        public bool RemovePlayer(string name)
        {
            if (Roster.Any(x => x.Name == name))
            {
                Roster.Remove(Roster.First(x => x.Name == name));
                Capacity++;
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            if (!Roster.Any(x => x.Name == name && x.Rank == "Member"))
            {
                var player = Roster.Where(x => x.Name == name).First();
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (!Roster.Any(x => x.Name == name && x.Rank == "Trial"))
            {
                var player = Roster.Where(x => x.Name == name).First();
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classs)
        {
            List<Player> kickedPlayers = new List<Player>();
            kickedPlayers = Roster.Where(x => x.Class == classs).ToList();

            foreach (var player in kickedPlayers)
            {
                Roster.Remove(player);
                Capacity++;
            }

            Player[] kicked = new Player[kickedPlayers.Count];
            kicked = kickedPlayers.ToArray();
            return kicked;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var item in Roster)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
