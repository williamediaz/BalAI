# Arquitectura

Esta documentación describe la arquitectura inicial (scaffold) de BalotoAI.

- Domain: Entidades del negocio (Ticket, etc.).
- Application: Casos de uso, CQRS (MediatR), DTOs, interfaces.
- Infrastructure: Implementaciones concretas: EF Core DbContext, servicios, integración ML.NET.
- Web: Razor Pages, Swagger, Serilog, integración de MediatR.
- Tests: xUnit con pruebas unitarias.

Próximos pasos:
- Implementar módulos estadísticos (Bayes, Markov, MonteCarlo avanzado, Algoritmo Genético).
- Añadir endpoints REST y Dashboard con Chart.js.
- Entrenar e integrar modelos ML.NET y exponer endpoints de inferencia.
