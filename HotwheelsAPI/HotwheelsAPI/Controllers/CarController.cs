using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotwheelsAPI.Azure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotwheelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        
        // GET api/car/all
        [HttpGet("all")]
        public JsonResult getAllCars()
        {
            var list = CarAzure.getAllCars();
            return new JsonResult(list);
        }

        //GET api/car/{id}
        [HttpGet("{id}")]
        public JsonResult getHotwheel(int id)
        {
            var list = CarAzure.getHotwheel(id);
            return new JsonResult(list);
        }
    }
}
