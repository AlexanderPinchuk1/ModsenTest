using Microsoft.AspNetCore.Identity;

namespace IdentityServer
{
    public static class ApplicationBuilderExtension
    {
        private const string login = "User";
        private const string password = "User1234!";

        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;
            if(serviceProvider == null)
            {
                return app;
            }

            await SeedUsersAsync(serviceProvider);

            return app;
        }

        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser<Guid>>>();
            if (userManager == null)
            {
                return;
            }

            var user = new IdentityUser<Guid>
            {
                UserName = login
            };

            await userManager.CreateAsync(user, password);
        }
    }
}
