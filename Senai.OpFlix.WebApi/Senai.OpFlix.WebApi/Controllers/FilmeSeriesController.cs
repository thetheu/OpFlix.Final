using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FilmeSeriesController : ControllerBase
    {
        private IFilmeSeriesRepository FilmeSeriesRepository { get; set; }

        public FilmeSeriesController()
        {
            FilmeSeriesRepository = new FilmeSeriesRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FilmeSeriesRepository.Listar());
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(FilmeSeries filmeSeries)
        {
            try
            {
                FilmeSeriesRepository.Cadastrar(filmeSeries);
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar" + ex});
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FilmeSeries filmeSeries = FilmeSeriesRepository.BuscarPorId(id);
            if (filmeSeries == null)
                return NotFound();
            return Ok(filmeSeries);
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(FilmeSeries filmeSeries)
        {
            try
            {
                FilmeSeries FilmeSeries = FilmeSeriesRepository.BuscarPorId(filmeSeries.IdFs);
                if (FilmeSeries == null)
                    return NotFound();

                FilmeSeriesRepository.Atualizar(filmeSeries);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Erro ao Atualizar"});
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FilmeSeriesRepository.Deletar(id);
            return Ok();
        }
    }
}