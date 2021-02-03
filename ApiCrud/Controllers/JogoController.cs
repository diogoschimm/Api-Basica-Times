using ApiCrud.Models;
using ApiCrud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly JogoRepository _jogoRepository;

        public JogoController()
        { 
            this._jogoRepository = new JogoRepository(StringConexao.DefaultConnection);
        }

        // GET: api/<JogoController>
        [HttpGet]
        public IEnumerable<Jogo> Get()
        {
            return this._jogoRepository.ObterTodos();
        }

        // GET api/<JogoController>/5
        [HttpGet("{id}")]
        public Jogo Get(int id)
        {
            return this._jogoRepository.ObterPorId(id);
        }

        // POST api/<JogoController>
        [HttpPost]
        public Jogo Post([FromBody] Jogo jogo)
        {
            return this._jogoRepository.Salvar(jogo);
        }

        // PUT api/<JogoController>/5
        [HttpPut("{id}")]
        public Jogo Put(int id, [FromBody] Jogo jogo)
        {
            jogo.IdJogo = id;
            return this._jogoRepository.Atualizar(jogo);
        }

        // DELETE api/<JogoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            this._jogoRepository.Excluir(id);
            return true;
        }
    }
}
