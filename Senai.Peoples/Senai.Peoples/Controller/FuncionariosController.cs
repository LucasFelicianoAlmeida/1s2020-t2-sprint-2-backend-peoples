using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.Domain;
using Senai.Peoples.Interfaces;
using Senai.Peoples.Repositories;

namespace Senai.Peoples.Controller
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionariosRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            _funcionarioRepository.Cadastrar(novoFuncionario);

            return StatusCode(201);

        }

        [HttpGet("{idBuscado}")]
        public IActionResult GetById(int idBuscado)
        {
            FuncionarioDomain FuncionarioBuscado = _funcionarioRepository.BuscarPorId(idBuscado);

            //Verifica se nenhum genero foi encontrado 
            if (idBuscado == null)
            {
                return StatusCode(404);
            }

            return Ok(FuncionarioBuscado);

        }

        [HttpDelete("{idDeletar}")]
        public IActionResult Delete(int idDeletar)
        {
            if (idDeletar == null)
            {
                return StatusCode(404);
            }
            _funcionarioRepository.Deletar(idDeletar);

            return StatusCode(201);

        }

        [HttpPut]
        public IActionResult PutIdUrl()
        {

        }
    }
}