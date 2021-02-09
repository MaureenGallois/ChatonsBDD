using System;
using Microsoft.EntityFrameworkCore;

namespace ChatonsBDD.Models
{
    public class ContexteBDD : DbContext
    {
        public DbSet<Categorie> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Il ne faut pas la chaiine de connexion ici, mais dans les paramètres appsettings
            //todo mettre la chaine de connexion ailleurs
            options.UseSqlite("Data Source=chatons.db");

        }
    }
}
