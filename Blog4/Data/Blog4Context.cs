using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog4.Models;

namespace Blog4.Models
{
    public class Blog4Context : DbContext
    {
        public Blog4Context (DbContextOptions<Blog4Context> options)
            : base(options)
        {
        }

        public DbSet<Blog4.Models.Mensagem> Mensagem { get; set; }

        public DbSet<Blog4.Models.Comentario> Comentario { get; set; }

        public DbSet<Blog4.Models.Categoria> Categoria { get; set; }
    }
}
