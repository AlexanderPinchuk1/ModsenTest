using IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<UserDbContext>();

builder.Services.AddIdentityServer()
       .AddAspNetIdentity<IdentityUser<Guid>>()
       .AddInMemoryClients(Config.GetClients())
       .AddInMemoryApiScopes(Config.GetApiScopes())
       .AddDeveloperSigningCredential();

var app = builder.Build();

app.PrepareDatabase().GetAwaiter().GetResult();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseIdentityServer();


app.Run();
