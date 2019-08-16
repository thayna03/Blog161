using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        [ForeignKey("MensagemId")]
        public int? MensagemId { get; set; }
        public virtual Mensagem Mensagem { get; set; }
    }
}
