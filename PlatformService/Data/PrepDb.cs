using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext? context)
        {
            if (context != null)
            {
                if (!context.Platforms.Any())
                {
                    Console.WriteLine("*** SEEDING DATA ***");
                    context.Platforms.AddRange(
                        new Platform() { Name = ".Net", Publisher = "Microsoft" },
                        new Platform() { Name = "SQL Server", Publisher = "Microsoft" },
                        new Platform() { Name = "AWS CLI", Publisher = "Amazon Web Services" }
                    );
                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Data already present");
                }
            }
        }
    }
}