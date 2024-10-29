using MauiPruebaMigracion.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MauiPruebaMigracion
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Configuración del DbContext usando la ruta proporcionada por ConexionDb
            builder.Services.AddDbContext<InventarioDbContext>(options =>
            {
                string dbPath = ConexionDb.DevolverRuta("venta.db"); // Llama al método en la clase ConexionDb para obtener la ruta
                options.UseSqlite($"Filename={dbPath}");
            });

            return builder.Build();
        }
    }
}
