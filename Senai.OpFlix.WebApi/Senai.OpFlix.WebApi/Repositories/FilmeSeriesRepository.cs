using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class FilmeSeriesRepository : IFilmeSeriesRepository
    {
        public List<FilmeSeries> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.FilmeSeries.Include(x => x.IdCategoriaNavigation).Include(x => x.IdClassificacaoNavigation).Include(x => x.IdIdentificacaoNavigation).Include(x => x.IdPlataformaNavigation).ToList();
                
            }
        }


        public void Cadastrar(FilmeSeries filmeSeries)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Add(filmeSeries);
                ctx.SaveChanges();
            }
        }


        public FilmeSeries BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.FilmeSeries.FirstOrDefault(x => x.IdFs == id);
            }
        }


        public void Atualizar(FilmeSeries filmeSeries)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                FilmeSeries FilmeSeriesBuscada = ctx.FilmeSeries.FirstOrDefault(x => x.IdFs == filmeSeries.IdFs);
                FilmeSeriesBuscada.Titulo = filmeSeries.Titulo;
                FilmeSeriesBuscada.TempoDuracao = filmeSeries.TempoDuracao;
                FilmeSeriesBuscada.Sinopse = filmeSeries.Sinopse;
                FilmeSeriesBuscada.IdPlataforma = filmeSeries.IdPlataforma;
                FilmeSeriesBuscada.IdIdentificacao = filmeSeries.IdIdentificacao;
                FilmeSeriesBuscada.IdClassificacao = filmeSeries.IdClassificacao;
                FilmeSeriesBuscada.IdCategoria = filmeSeries.IdCategoria;
                FilmeSeriesBuscada.Veiculo = filmeSeries.Veiculo;
                ctx.Update(FilmeSeriesBuscada);
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                FilmeSeries filmeSeries = ctx.FilmeSeries.Find(id);
                ctx.FilmeSeries.Remove(filmeSeries);
                ctx.SaveChanges();
            }
        }

    }
}
