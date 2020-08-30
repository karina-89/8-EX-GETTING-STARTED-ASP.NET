using empleados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empleados.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EmpleadoContexto(
                serviceProvider.GetRequiredService<DbContextOptions<EmpleadoContexto>>()))
            {
                // Look for any board games.
                if (context.EmpleadoItems.Any())
                {
                    return;   // Data was already seeded
                }

                context.EmpleadoItems.AddRange(
                    new Empleado
                    {
                        Id = 1,
                        Nombre = "José",
                        Apellidos = "Sanchez",
                        Cargo = "",
                        Sueldo = 4
                    },
                    new Empleado
                    {
                        Id = 2,
                        Nombre = "Marta",
                        Apellidos = "Ruíz",
                        Cargo = "",
                        Sueldo = 4
                    });

                context.SaveChanges();
            }
        }
    }
}
