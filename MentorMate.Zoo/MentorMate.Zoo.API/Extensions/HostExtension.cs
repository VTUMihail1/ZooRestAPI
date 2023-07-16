using MentorMate.Zoo.Data.Seed;

namespace MentorMate.Zoo.API.Extensions
{
    public static class HostExtension
    {
        public static async Task InitializeDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var database = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();

                await database.InitializeAsync();
            }
        }
    }
}
