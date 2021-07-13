using Microsoft.EntityFrameworkCore;
using SmartApartmentAplication.Helpers;
using SmartApartmentAplication.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Property
{
    public class PropertyService
    {
        private readonly SmartApartmentContext _context;

        public PropertyService(SmartApartmentContext context)
        {
            _context = context;
        }

        public IEnumerable<propertyHeaderDTO> GetAll()
        {
            var data = _context.propertyHeader.Include(x => x.property).Where(x => x.isActive == Constants.Active);
            return propertyHeaderDTO.FromModelToDTO(data);
        }

        public async Task<Response> GetById(long id)
        {
            var property = await _context.propertyHeader.Include(e => e.property).FirstOrDefaultAsync(r => r.id == id && r.isActive == Constants.Active);
            if (property == null)
            {
                return new Response { message = "property not exists" };
            }


            return new Response { data = propertyHeaderDTO.FromModelToDTO(property) };
        }

        public async Task<Response> Post(propertyHeaderDTO propertyHeaderDTO)
        {

            var SavedMgmt = await _context.propertyHeader.FirstOrDefaultAsync(r => r.property.name == propertyHeaderDTO.property.name && r.property.propertyID == propertyHeaderDTO.property.propertyID);
            if (SavedMgmt != null)
            {
                return new Response { message = "This property already exists in our system" };
            }

            _context.propertyHeader.Add(propertyHeaderDTO.FromDTOToModel(propertyHeaderDTO));
            await _context.SaveChangesAsync();
            return new Response { message = "Added sucefully" };
        }

        public async Task<List<Response>> Post(IEnumerable<propertyHeaderDTO> items)
        {
            List<Response> responses = new List<Response>();
            foreach (var item in items)
            {
                responses.Add(await Post(item));
            }

            return responses;
        }
    }
}
