using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApiDbContext : IdentityDbContext
    {
        //Permite tener acceso a la tabla de la base de datos
        public DbSet<FootballTeam> Teams { get; set; } 
        public DbSet<RegisterPlayer> Player { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<ResultEvent> Results { get; set; }
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<DataEvent> DataEvents { get; set; }
        //Crear constructor y recibe la configuracion que necesita Entity Framework
        //Se lo pasamos a DbContext
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        //Prevenir que se crean tablas que no se necesitan
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Se evita que se cree una tabla entity en el modelo de base de datos
            modelBuilder.Ignore<Entity>();
            //modelBuilder.Ignore<DataEvent>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
