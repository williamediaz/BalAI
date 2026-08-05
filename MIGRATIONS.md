# Migraciones y EF Core

Para trabajar con migraciones en el proyecto BalAI, uso el DbContext definido en src/BalAI.Infrastructure/Persistence/BalAIDbContext y la factoría de tiempo de diseño.

Comandos útiles:

- Añadir una migración (desde la carpeta raíz del repo):
  dotnet ef migrations add InitialCreate --project src/BalAI.Infrastructure --startup-project src/BalAI.Api --context BalAI.Infrastructure.Persistence.BalAIDbContext

- Aplicar migraciones a la BD:
  dotnet ef database update --project src/BalAI.Infrastructure --startup-project src/BalAI.Api --context BalAI.Infrastructure.Persistence.BalAIDbContext

Notas:
- La factoría BalAIDesignTimeFactory se usa para que las herramientas EF Core puedan crear el DbContext en tiempo de diseño.
- Asegúrate de tener `dotnet-ef` instalado globalmente: dotnet tool install --global dotnet-ef
- La cadena de conexión por defecto en appsettings.Development.json usa SQL Server local (puedes cambiarla según tu entorno o mediante variables de entorno).
