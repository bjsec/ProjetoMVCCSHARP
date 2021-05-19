using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVCCSHARP.Models
{
    public class NoticiaViewModel
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Conteudo { get; set; }

        public IFormFile Imagem { get; set; }
    }
}
