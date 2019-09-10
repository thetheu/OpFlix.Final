using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Plataforma
    {
        public Plataforma()
        {
            FilmeSeries = new HashSet<FilmeSeries>();
        }

        public int IdPlataforma { get; set; }
        public string Nome { get; set; }

        public ICollection<FilmeSeries> FilmeSeries { get; set; }
    }
}
