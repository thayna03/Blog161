using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.ViewsModel
{
    public class MensagemViewModel
    {
        public IEnumerable<Mensagem> Mensagens { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
    }
}
