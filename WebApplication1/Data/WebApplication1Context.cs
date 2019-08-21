using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class WebApplication1Context : IdentityDbContext<User>

    {
        public WebApplication1Context(DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Comentario> Comentario { get; set; }

        public DbSet<Mensagem> Mensagem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    CategoriaId = 1,
                    Descricao = "Suspense"
                },
                new Categoria
                {
                    CategoriaId = 2,
                    Descricao = "Romance"
                });
        }
    }
}
