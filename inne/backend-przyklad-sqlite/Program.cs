using backend_przyklad_sqlite.Data;
using Microsoft.EntityFrameworkCore;

namespace backend_przyklad_sqlite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dodanie us�ug do kontenera DI (Dependency Injection)
            builder.Services.AddControllers();

            // Dodanie wsparcia dla Swagger/OpenAPI
            // Dowiedz si� wi�cej o konfiguracji Swagger/OpenAPI pod tym linkiem: https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Konfiguracja po��czenia z baz� danych SQLite
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Konfiguracja potoku ��da� HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Wymuszenie przekierowania na HTTPS
            app.UseHttpsRedirection();

            // W��czenie autoryzacji
            app.UseAuthorization();

            // Mapowanie kontroler�w API
            app.MapControllers();

            // Tworzenie bazy danych, je�li jeszcze nie istnieje
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated(); // Tworzy baz� danych, je�li nie istnieje
            }

            // Uruchomienie aplikacji
            app.Run();
        }
    }
}
