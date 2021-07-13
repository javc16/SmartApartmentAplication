using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Mgmt
{
    [Route("api/[controller]")]
    [ApiController]
    public class mgmtController : ControllerBase
    {
        private readonly mgmtService _mgmtService;

        public mgmtController(mgmtService mgmtService)
        {
            _mgmtService = mgmtService;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<mgmtHeader>> GetAll()
        {
            return Ok(_mgmtService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<mgmtHeader>> GetById(long id)
        {
            return Ok(await _mgmtService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<mgmtHeader>> Post(mgmtHeader item)
        {
            return Ok(await _mgmtService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<mgmtHeader>> PutCiudadano(int id, mgmtHeader item)
        {
            return Ok(await _mgmtService.Put(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<mgmtHeader>> DeleteById(int id)
        {
            return Ok(await _mgmtService.Delete(id));
        }
    }
}
