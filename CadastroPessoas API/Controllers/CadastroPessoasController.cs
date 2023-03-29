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


        

        [HttpGet("")]
        public IActionResult Get_Pessoas()
        {
            List<Cadastro> pessoas = new List<Cadastro>();
            pessoas.Add(new Cadastro(1, "Cleberson", "1423432", "12/07/2023"));
            pessoas.Add(new Cadastro(2, "Vivaldi", "5332756", "10/02/1984"));
            pessoas.Add(new Cadastro(3, "Gopher", "65465436", "05/09/1989"));

            return Ok(pessoas);
        }



        [HttpGet("{id:int}")]
        public IActionResult Get_Pessoa([FromRoute]int id)
        {
            List<Cadastro> pessoas = new List<Cadastro>();
            pessoas.Add(new Cadastro(1, "Cleberson", "1423432", "12/07/2023"));
            pessoas.Add(new Cadastro(2, "Vivaldi", "5332756", "10/02/1984"));
            pessoas.Add(new Cadastro(3, "Gopher", "65465436", "05/09/1989"));
            return Ok(pessoas.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cadastro pessoa)
        {
            List<Cadastro> pessoas = new List<Cadastro>();
            pessoas.Add(new Cadastro(1, "Cleberson", "1423432", "12/07/2023"));
            pessoas.Add(new Cadastro(2, "Vivaldi", "5332756", "10/02/1984"));
            pessoas.Add(new Cadastro(3, "Gopher", "65465436", "05/09/1989"));
            int id_counter = 4;
            pessoa.Id = id_counter;
            id_counter++;


            pessoas.Add(pessoa);


            return StatusCode(StatusCodes.Status201Created, pessoas);

        }



        [HttpPut("")]
        public IActionResult Update([FromQuery] int id, [FromBody] Cadastro model)
        {
            if (id == 0)
            {
                return BadRequest("Este id não pode ser atualizado");
            }

            List<Cadastro> pessoas = new List<Cadastro>();
            pessoas.Add(new Cadastro(1, "Cleberson", "1423432", "12/07/2023"));
            pessoas.Add(new Cadastro(2, "Vivaldi", "5332756", "10/02/1984"));
            pessoas.Add(new Cadastro(3, "Gopher", "65465436", "05/09/1989"));

            Cadastro pessoa_antiga = pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa_antiga == null)
            {
                return Ok($"Usuário com ID:{id} não encontrado!");
            }

            pessoas.Remove(pessoa_antiga);
            pessoas.Insert(id - 1, model);
            return Ok(pessoas);



        }



        [HttpDelete("")]
        public IActionResult Delete([FromQuery] int id)
        {
            List<Cadastro> pessoas = new List<Cadastro>();
            pessoas.Add(new Cadastro(1, "Cleberson", "1423432", "12/07/2023"));
            pessoas.Add(new Cadastro(2, "Vivaldi", "5332756", "10/02/1984"));
            pessoas.Add(new Cadastro(3, "Gopher", "65465436", "05/09/1989"));

            if (id == 0)
            {
                return BadRequest("Este id não pode ser deletado");
            } else
            {
                Cadastro pessoa = pessoas.FirstOrDefault(p => p.Id == id);

                if (pessoa == null)
                {
                    return Ok($"Usuário com ID:{id} não encontrado!");
                }
                else
                {
                    pessoas.Remove(pessoa);
                    return Ok(pessoas);
                }
            }


        }
    }
}