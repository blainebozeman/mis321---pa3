using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.Controllers;
using api.Models;
using api.Models.Interfaces;




namespace api.Controllers
{   
    // [EnableCors("OpenPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        // GET: api/Drivers
        // [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Drivers> Get()
        {
            IGetAllDrivers readObject = new ReadDrivers();
            return readObject.GetAllDrivers();

            
        }

        // GET: api/Drivers/5
        // [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Drivers Get(int id)
        {
            IGetDriver readObject = new ReadDrivers();
            return readObject.GetDriver(id);
        }

        // POST: api/Drivers
        // [EnableCors("OpenPoliicy")]
        [HttpPost]
        public void Post([FromBody]Drivers driver)
        {
            IAddDriver addObject = new SaveDriver();
            addObject.AddDriver(driver);
        }

        // PUT: api/Drivers/5
        [HttpPut("{id}")]
        public void Put(int id, int rating, [FromBody] Drivers driver)
        {
            IEditDriver editObject = new UpdateDrivers();
            editObject.EditDrivers(driver);

        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteDriver deleteObject = new DeleteDrivers();
            deleteObject.DeleteDriver(id);
        }
    }
}
