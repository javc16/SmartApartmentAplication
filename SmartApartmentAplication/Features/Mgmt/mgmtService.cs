using Microsoft.EntityFrameworkCore;
using SmartApartmentAplication.Helpers;
using SmartApartmentAplication.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Mgmt
{
    public class mgmtService
    {
        private readonly SmartApartmentContext _context;

        public mgmtService(SmartApartmentContext context)
        {
            _context = context;
        }

        public IEnumerable<mgmtHeaderDTO> GetAll()
        {
            var data = _context.mgmtHeader.Include(x => x.mgmt).Where(x => x.isActive == Constants.Active);
            return mgmtHeaderDTO.FromModelToDTO(data);
        }

        public async Task<Response> GetById(long id)
        {
            var mgmt = await _context.mgmtHeader.Include(e => e.mgmt).FirstOrDefaultAsync(r => r.id == id && r.isActive == Constants.Active);
            if (mgmt == null)
            {
                return new Response { message = "mgmt not exists" };
            }


            return new Response { data = mgmtHeaderDTO.FromModelToDTO(mgmt) };
        }

        public async Task<Response> Post(mgmtHeaderDTO mgmtHeaderDTO)
        {

            var SavedMgmt = await _context.mgmtHeader.FirstOrDefaultAsync(r => r.mgmt.name == mgmtHeaderDTO.mgmt.name);
            if (SavedMgmt != null)
            {
                return new Response { message = "This mgmt already exists in our system" };
            }

            _context.mgmtHeader.Add(mgmtHeaderDTO.FromDTOToModel(mgmtHeaderDTO));
            await _context.SaveChangesAsync();
            return new Response { message = "Added sucefully" };
        }

        public async Task<List<Response>> Post(IEnumerable<mgmtHeaderDTO> items)
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
