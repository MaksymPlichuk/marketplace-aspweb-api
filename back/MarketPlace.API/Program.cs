using MarketPlace.DAL;
using MarketPlace.DAL.Entities.Identity;
using MarketPlace.DAL.Initializer;
using MarketPlace.DAL.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

//builder.Services.ConfigureHttpJsonOptions(options =>
//{
//    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
//});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddIdentity<AppUserEntity, AppRoleEntity>(opt =>
{
    opt.User.RequireUniqueEmail = false;
    opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<AppDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("LocalDB");
    options.UseNpgsql(connectionString);
});

string CORSPolicy = "AllowAll";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(CORSPolicy, cfg =>
    {
        cfg.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

builder.Services.AddScoped<ItemCategoryRepository>();
builder.Services.AddScoped<ItemRepository>();

var app = builder.Build();

app.UseCors(CORSPolicy);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

await app.SeedAsync();
app.Run();