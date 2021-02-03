using ApiCrud.Models;
using ApiCrud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly TimeRepository _timeRepository;

        public TimeController()
        {
            this._timeRepository = new TimeRepository(StringConexao.DefaultConnection);
        }

        // GET: api/<TimeController>
        [HttpGet]
        public IEnumerable<Time> Get()
        {
            return this._timeRepository.ObterTodos();
        }

        // GET api/<TimeController>/5
        [HttpGet("{id}")]
        public Time Get(int id)
        {
            return this._timeRepository.ObterPorId(id);
        }

        // POST api/<TimeController>
        [HttpPost]
        public Time Post([FromBody] Time jogo)
        {
            return this._timeRepository.Salvar(jogo);
        }

        // PUT api/<TimeController>/5
        [HttpPut("{id}")]
        public Time Put(int id, [FromBody] Time jogo)
        {
            jogo.IdTime = id;
            return this._timeRepository.Atualizar(jogo);
        }

        // DELETE api/<TimeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            this._timeRepository.Excluir(id);
            return true;
        }
    }
}
