using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeamsPlayers.Models
{
    public class TeamsDbContext : DbContext
    {
        public TeamsDbContext(DbContextOptions<TeamsDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Team> Teams { get; set; }
    }
}
