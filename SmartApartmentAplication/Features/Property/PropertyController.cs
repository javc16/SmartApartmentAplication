using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Property
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public PropertyController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<propertyHeaderDTO>> GetAll()
        {
            return Ok(_propertyService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<propertyHeaderDTO>> GetById(long id)
        {
            return Ok(await _propertyService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<propertyHeaderDTO>> Post(propertyHeaderDTO item)
        {
            return Ok(await _propertyService.Post(item));
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<propertyHeaderDTO>> PostAll(List<propertyHeaderDTO> item)
        {
            return Ok(await _propertyService.Post(item));
        }
    }
}
