using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog4.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categorias { get; set; }
        [ForeignKey("ComentarioId")]
        public int ComentarioId { get; set; }
        public virtual Comentario Comentarios { get; set; }
    }
}
