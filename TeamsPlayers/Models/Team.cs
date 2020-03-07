using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamsPlayers.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Player> Players { get; set; }
    }
}
