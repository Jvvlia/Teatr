
namespace Teatr_BG.Migrations
{
    using Microsoft.Ajax.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Teatr_BG.Models.DbModels;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A configuration. This class cannot be inherited. </summary>
    ///
    /// <remarks>   Julia, 24.05.2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    internal sealed class Configuration : DbMigrationsConfiguration<Teatr_BG.Models.DatabaseContext>
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        ///
        /// <remarks>
        /// Note that the database may already contain seed data when this method runs. This means that
        /// implementations of this method must check whether or not seed data is present and/or up-to-
        /// date and then only make changes if necessary and in a non-destructive way. The
        /// <see cref="M:System.Data.Entity.Migrations.DbSetMigrationsExtensions.AddOrUpdate``1(System.Data.Entity.IDbSet{``0},``0[])" />
        /// can be used to help with this, but for seeding large amounts of data it may be necessary to
        /// do less granular checks if performance is an issue. If the <see cref="T:System.Data.Entity.MigrateDatabaseToLatestVersion`2" />
        /// database initializer is being used, then this method will be called each time that the
        /// initializer runs. If one of the <see cref="T:System.Data.Entity.DropCreateDatabaseAlways`1" />,
        /// <see cref="T:System.Data.Entity.DropCreateDatabaseIfModelChanges`1" />, or <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1" />
        /// initializers is being used, then this method will not be called and the Seed method defined
        /// in the initializer should be used instead.
        /// </remarks>
        ///
        /// <param name="context">  Context to be used for updating seed data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void Seed(Teatr_BG.Models.DatabaseContext context)
        {
           var actors = new List<Actor>
            {
                new Actor {FName="Tomasz", LName = "Karolak", Bio = "Polski aktor teatralny, telewizyjny i filmowy, muzyk, lektor, reżyser teatralny, stand uper, przedsiębiorca, satyryk i piosenkarz."},
                new Actor {FName="Cezary", LName="Pazura", Bio = "Zadebiutował w 1986 rolą druha Pumy w filmie Czarne Stopy." },
                new Actor {FName="Jerzy", LName="Stuhr", Bio= "Laureat Polskiej Nagrody Filmowej za rolę drugoplanową w filmie Persona non grata i nagrody specjalnej za osiągnięcia życia."}
                
            };
            actors.ForEach(s=> context.Actors.Add(s));
            context.SaveChanges();

            var plays = new List<Play>
            {
                new Play {NameP="Balladyna", DateP=DateTime.Parse("2023-09-01"), Price=12.3M},
                new Play {NameP="Tango", DateP=DateTime.Parse("2023-12-01"), Price= 20.0M},
                new Play {NameP="Boska Komedia", DateP=DateTime.Parse("2023-07-01"), Price= 25.0M}
            };
            plays.ForEach(s => context.Plays.Add(s));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client {FirstName="Anna", LastName="Nowicka", PhoneNumber="123456789"},
                new Client {FirstName="Adam", LastName="Kowalski", PhoneNumber="156876789"},
                new Client {FirstName="Joanna", LastName="Stalmach", PhoneNumber="678456789"}
            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var sales = new List<Sale>
            {
                new Sale
                {
                    ClientID = clients.Single(s => s.FirstName=="Anna").ClientID,
                    PlayID = plays.Single(s =>s.NameP=="Tango").PlayID
                },
                new Sale
                {
                    ClientID = clients.Single(s => s.FirstName=="Adam").ClientID,
                    PlayID = plays.Single(s =>s.NameP=="Boska Komedia").PlayID
                },
                new Sale
                {
                    ClientID = clients.Single(s => s.FirstName=="Joanna").ClientID,
                    PlayID = plays.Single(s =>s.NameP=="Balladyna").PlayID
                }
            };
            foreach (var s in sales)
            {
                var saleInDataBase = context.Sales.Where(
                    a => a.ClientID == s.ClientID &&
                    a.PlayID == s.PlayID).SingleOrDefault();
                if(saleInDataBase == null)
                {
                    context.Sales.Add(s);
                }
            }
            context.SaveChanges();
        }
    }
}
