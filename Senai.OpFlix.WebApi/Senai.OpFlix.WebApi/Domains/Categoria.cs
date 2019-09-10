using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            FilmeSeries = new HashSet<FilmeSeries>();
        }

        public int IdCategoria { get; set; }
        public string Nome { get; set; }

        public ICollection<FilmeSeries> FilmeSeries { get; set; }
    }
}
