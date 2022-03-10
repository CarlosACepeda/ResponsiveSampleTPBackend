using ResponsiveSampleTPBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponsiveSampleTPBackend.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var hobby1 = new Hobby { Name = "Correr" };
            var hobby2 = new Hobby { Name = "Cantar" };
            var hobby3 = new Hobby { Name = "Saltar" };
            var hobby4 = new Hobby { Name = "Trotar" };
            var hobby5 = new Hobby { Name = "Ver Peliculas" };
            var hobby6 = new Hobby { Name = "Leer" };
            var users = new User[]
            {
                new User { Name = "Carlos", Username = "teleperformance", Password = "qwerty987654*" }
            };
            foreach (var user in users)
            {
                user.Hobbies.Add(hobby1);
                user.Hobbies.Add(hobby2);
                context.Users.Add(user);
            }
            context.Hobbies.Add(hobby3);
            context.Hobbies.Add(hobby4);
            context.Hobbies.Add(hobby5);
            context.Hobbies.Add(hobby6);
            
            context.SaveChanges();
        }
    }
}
