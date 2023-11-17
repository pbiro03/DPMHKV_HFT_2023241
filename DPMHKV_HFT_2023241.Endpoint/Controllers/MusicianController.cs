using DPMHKV_HFT_2023241.Logic.Interfaces;
using DPMHKV_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DPMHKV_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        // GET: api/<MusicianController>
        IMusician logic;

        public MusicianController(IMusician logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Musician> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<MusicianController>/5
        [HttpGet("{id}")]
        public Musician Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<MusicianController>
        [HttpPost]
        public void Create([FromBody] Musician value)
        {
            this.logic.Create(value);
        }

        // PUT api/<MusicianController>/5
        [HttpPut]//("{id}")]
        public void Update([FromBody] Musician value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<MusicianController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
