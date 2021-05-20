using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace AdministradorCafeteriaVirtual.Models
{
    public class CafeteriaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<Pregunta> Preguntas { get; set; }

        public DbSet<PrivateMessage> PrivateMessages { get; set; }

        public DbSet<Respuesta> Respuestas { get; set; }

        public DbSet<UserRoom> UserRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}