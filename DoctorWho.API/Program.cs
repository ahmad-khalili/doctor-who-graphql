using DoctorWho.API.Schemas;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using GraphQL;
using GraphQL.FluentValidation;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DoctorWhoCoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DoctorWhoDb"]);
});

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();

builder.Services.AddScoped<IEnemyRepository, EnemyRepository>();

builder.Services.AddScoped<ICompanionRepository, CompanionRepository>();

builder.Services.AddSingleton<ISchema, DoctorWhoSchema>
    (services => new DoctorWhoSchema(new SelfActivatingServiceProvider(services)));

var validatorCache = new ValidatorInstanceCache();
validatorCache.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies()[1]);

builder.Services.AddGraphQL(options => options.ConfigureExecution((opt, next) =>
    {
        opt.EnableMetrics = true;
        opt.UseFluentValidation(validatorCache);
        return next(opt);
    }).AddSystemTextJson()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL();

app.Run();