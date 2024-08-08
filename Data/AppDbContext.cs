using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {

        }

        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
        
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<LivroModel>(entity =>
            {
                entity.HasKey(e => new { e.Id });
            });
        }


    }
}
