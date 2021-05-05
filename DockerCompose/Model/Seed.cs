using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DockerCompose.Model
{   
    public static class Seed
    {
        public static void PrepPopulation(IApplicationBuilder builder){

            using (var serviceScope = builder.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetService<ComposeContext>());
            }

        }

        public static void SeedData(ComposeContext composeContext)
        {
            composeContext.Database.Migrate();
            if (!composeContext.Users.Any())
            {
                composeContext.Users.AddRange(
                    new User{ Nombre = "Alvaro"},
                    new User{ Nombre = "Jose"},
                    new User{ Nombre = "Miguel"},
                    new User{ Nombre = "Juan"}
                );

                composeContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data");
            }
        }
        
    }
    
}