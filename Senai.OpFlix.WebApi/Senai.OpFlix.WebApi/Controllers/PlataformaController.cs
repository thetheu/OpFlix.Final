using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class PlataformaController : ControllerBase
    {
        private IPlataformaRepository PlataformaRepository { get; set; }
        public PlataformaController()
        {
            PlataformaRepository = new PlataformaRepository();
        }
        
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.listar());
        }


        [HttpPost]
        public IActionResult Cadastrar (Plataforma plataforma)
        {
            try
            {
                PlataformaRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = "Erro Ao Cadastrar" + ex.Message });
            }  
        }


        [HttpPut]
        public IActionResult Atualizar(Plataforma plataforma)
        {
            try
            {
                Plataforma PlataformaBuscada = PlataformaRepository.BuscarPorId(plataforma.IdPlataforma);
                if (PlataformaBuscada == null)
                    return NotFound();

                PlataformaRepository.Atualizar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensgem = "Erro Ao Atualizar" });
            }
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Plataforma Plataforma = PlataformaRepository.BuscarPorId(id);
            if (Plataforma == null)
                return NotFound();
            return Ok(Plataforma);
        }
    }
}