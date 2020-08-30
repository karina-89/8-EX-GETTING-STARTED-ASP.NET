using empleados.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empleados.Data
{
    public class EmpleadoContexto : DbContext
    {
        public EmpleadoContexto(DbContextOptions<EmpleadoContexto> options) : base(options)
        {
        }

        // Crear el DbSet
        public DbSet<Empleado> EmpleadoItems { get; set; }
    }
}
