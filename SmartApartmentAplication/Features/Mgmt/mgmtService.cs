using Microsoft.EntityFrameworkCore;
using SmartApartmentAplication.Helpers;
using SmartApartmentAplication.MyContext;
using SmartApartmentAplication.Repository;
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

        public  IEnumerable<mgmtHeader> GetAll()
        {
            return  _context.mgmtHeader.Include(x=>x.mgmt).Where(x=>x.isActive == Constants.Active);
        }

        public async Task<Response> GetById(long id)
        {
            var mgmt = await _context.mgmtHeader.Include(e => e.mgmt).FirstOrDefaultAsync(r => r.id == id  && r.isActive == Constants.Active);
            if (mgmt == null)
            {
                return new Response { message = "mgmt not exists" };
            }

            return new Response { data = mgmt };
        }

        public async Task<Response> Post(mgmtHeader mgmtHeader)
        {
     
            var SavedMgmt = await _context.mgmtHeader.FirstOrDefaultAsync(r => r.id == mgmtHeader.id);
            if (SavedMgmt != null)
            {
                return new Response { message = "This mgmt already exists in our system" };
            }           
            _context.mgmtHeader.Add(mgmtHeader);
            await _context.SaveChangesAsync();
            return new Response { message = "Added sucefully" };
        }

        public async Task<Response> Put(mgmtHeader mgmtHeader)
        {           
            _context.Entry(mgmtHeader).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { message = "Information modified sucefully" };
        }

        public async Task<Response> Delete(int id)
        {
            var mgmt = await _context.mgmtHeader.FindAsync(id);
            if (mgmt == null)
            {
                return new Response { message = "No have a mgmt with this id" };
            }
            mgmt.isActive = Constants.Inactive;
            _context.Entry(mgmt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { message = $"Mgmt {mgmt.mgmt.name} deleted correctly" };
        }
    }
}
