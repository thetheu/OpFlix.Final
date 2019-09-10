using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public List<Plataforma> listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataforma.ToList();
            }
        }


        public Plataforma BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }


        public void Cadastrar(Plataforma plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Add(plataforma);
                    ctx.SaveChanges();
            }
        }


        public void Atualizar(Plataforma plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataforma PlataformaBuscada = ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == plataforma.IdPlataforma);
                PlataformaBuscada.Nome = plataforma.Nome;
                PlataformaBuscada.FilmeSeries = plataforma.FilmeSeries;
                ctx.Plataforma.Update(PlataformaBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
