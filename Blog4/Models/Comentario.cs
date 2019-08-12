using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog4.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public List<Mensagem> mensagems { get; set; }


    }
}
