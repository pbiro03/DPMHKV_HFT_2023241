using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DPMHKV_HFT_2023241.Logic.Interfaces;
using DPMHKV_HFT_2023241.Models;

namespace DPMHKV_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        IGuitar logic;

        public GuitarController(IGuitar logic)
        {
            this.logic = logic;
        }

        // GET: api/<GuitarController>
        [HttpGet]
        public IEnumerable<Guitar> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<GuitarController>/5
        [HttpGet("{id}")]
        public Guitar Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<GuitarController>
        [HttpPost]
        public void Create([FromBody] Guitar value)
        {
            this.logic.Create(value);
        }

        // PUT api/<GuitarController>/5
        [HttpPut("{id}")]
        public void Update( [FromBody] Guitar value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<GuitarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
