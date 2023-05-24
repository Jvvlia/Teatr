using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Teatr_BG.Models.DbModels;

namespace Teatr_BG.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("BazaDBContext") { }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Sale> Sales { get; set; }

        public System.Data.Entity.DbSet<Teatr_BG.Models.DbModels.Play> Plays { get; set; }
    }
}