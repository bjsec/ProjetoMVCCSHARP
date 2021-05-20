using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVCCSHARP.Models
{
    public class NoticiaModel
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Conteudo { get; set; }
        [NotMappedAttribute]
        public IFormFile ImagemFile { get; set; }

        public string ImagemName { get; set; }

        public NoticiaModel(string titulo,string resumo,string conteudo,IFormFile imagemFile)
        {
            Titulo = titulo;
            Resumo = resumo;
            Conteudo = conteudo;
            ImagemFile = imagemFile;
        }

        public NoticiaModel(string titulo,string resumo,string conteudo,string imagemName)
        {           
            Titulo = titulo;
            Resumo = resumo;
            Conteudo = conteudo;
            ImagemName = imagemName;
        }

        public NoticiaModel()
        {
        }
    }
}
