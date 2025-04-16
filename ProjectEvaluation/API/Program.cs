using Application;
using Domain.Entities;
using Infrastructure;
using IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(ApplicationLayer).Assembly,
        typeof(Program).Assembly
    );
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Context>();
    db.Database.Migrate();

    // Populate Order related entities (Company, Address,...)
    // to fully test Order creation without having to manually populate other tables
    if (!db.Companies.Any())
    {
        db.Companies.Add(
            new Company
            {
                Id = Guid.Parse("4e70cc6d-b139-4e26-9d8d-ecce10614531"),
                CNPJ = "04252011000110",
                CompanyName = "Serious Business",
                TradeName = "Monkey Business",
                Adresses = new[] {
                    new Address
                    {
                        Id = Guid.Parse("842857f5-2e09-40a3-9c35-8832fcc62e0f"),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = null,
                        Number = 1,
                        City = "Another City",
                        Neighborhood = "Uptown",
                        PostalCode = "67890",
                        StreetName = "Secondary Street",
                        CompanyId = Guid.Parse("4e70cc6d-b139-4e26-9d8d-ecce10614531"),
                        Company = null
                    }
                },
                ContactUser = new[] {
                    new User
                    {
                        Id= Guid.Parse("e310b670-d6fe-4999-9b0a-639a8b925e9b"),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = null,
                        Email = "admin@admin.com",
                        FirstName = "Joe",
                        LastName = "Doe",
                        Password = "S3cur3P4$$w0rD",
                        Phone = "+55988888888"
                    },
                },
                Phones = new[] {
                    new Phone
                    {
                        Id = Guid.Parse("1472184c-06fb-4a91-912c-43f1d284b516"),
                        CreatedAt= DateTime.UtcNow,
                        UpdatedAt = null,
                        Number = "+55988888888"
                    },
                },
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            });

        db.SaveChanges();
    }

}
    

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
