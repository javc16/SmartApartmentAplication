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
        public  ActionResult<IEnumerable<mgmtHeaderDTO>> GetAll()
        {
            return Ok(_mgmtService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<mgmtHeaderDTO>> GetById(long id)
        {
            return Ok(await _mgmtService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<mgmtHeaderDTO>> Post(mgmtHeaderDTO item)
        {
            return Ok(await _mgmtService.Post(item));
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<mgmtHeaderDTO>> PostAll(List<mgmtHeaderDTO> item)
        {
            return Ok(await _mgmtService.Post(item));
        }
    }
}
