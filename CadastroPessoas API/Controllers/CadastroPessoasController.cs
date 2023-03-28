using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using CadastroPessoas_API.Models;
using System.Reflection;

namespace CadastroPessoas_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroPessoasController : ControllerBase
    {
        private readonly ILogger<CadastroPessoasController> _logger;

        public CadastroPessoasController(ILogger<CadastroPessoasController> logger)
        {
            _logger = logger;
        }

        public List<Cadastro> pessoas = new List<Cadastro>();
        public int id_counter = 1;



        [HttpGet("")]
        public IActionResult Get_Pessoas()
        {
            return Ok(pessoas);
        }



        [HttpGet("{id:int}")]
        public IActionResult Get_Pessoa([FromRoute]int id)
        {
            return Ok(pessoas.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost("/new")]
        public IActionResult Create([FromBody] Cadastro model)
        {
            model.Id = id_counter;
            pessoas.Add(model);
            id_counter++;

            return StatusCode(StatusCodes.Status201Created, model);

        }



        [HttpPut("/edit")]
        public IActionResult Update([FromQuery] int id, [FromBody] Cadastro model)
        {
            if (id == 0)
            {
                return BadRequest("Este id não pode ser atualizado");
            }

            pessoas.Insert(id, model);
            return Ok(model);
        }



        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int id)
        {

            if (id == 0)
            {
                return BadRequest("Este id não pode ser deletado");
            } else
            {
                Cadastro pessoa = (Cadastro)Get_Pessoa(id);

                if (pessoa == null)
                {
                    return Ok($"Usuário com ID:{id} não encontrado!");
                }
                else
                {
                    pessoas.Remove(pessoa);
                    return Ok(pessoa);
                }
            }


        }
    }
}