using DPMHKV_HFT_2023241.Logic.Interfaces;
using DPMHKV_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DPMHKV_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGuitar logic;

        public StatController(IGuitar logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Musician> MusiciansWithExpensiveGuitar()
        {
            return logic.MusiciansWithExpensiveGuitar();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountGuitarsByBrand()
        {
            return logic.CountGuitarsByBrand();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return logic.AVGPriceByBrands();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountGuitarsByMusician()
        {
            return CountGuitarsByBrand();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> GuitarsInBands()
        {
            return logic.GuitarsInBands();
        }


    }

}
