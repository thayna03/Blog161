using System;
using System.Collections.Generic;
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
        public string Categoria { get; set; }
    }
}
