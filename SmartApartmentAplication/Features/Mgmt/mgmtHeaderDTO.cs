using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Mgmt
{
    public class mgmtHeaderDTO
    {
        public mgmtDetailDTO mgmt { get; set; }

        public static mgmtHeaderDTO FromModelToDTO(mgmtHeader mgmtHeader)
        {

            return mgmtHeader != null ? new mgmtHeaderDTO
            {                
                mgmt= mgmtDetailDTO.FromModelToDTO(mgmtHeader.mgmt)
            } : null;
        }

        public static IEnumerable<mgmtHeaderDTO> FromModelToDTO(IEnumerable<mgmtHeader> mgmtHeader)
        {
            if (mgmtHeader == null)
            {
                return new List<mgmtHeaderDTO>();
            }
            List<mgmtHeaderDTO> mgmtHeaderData = new List<mgmtHeaderDTO>();

            foreach (var item in mgmtHeader)
            {
                mgmtHeaderData.Add(FromModelToDTO(item));
            }

            return mgmtHeaderData;
        }


        public static mgmtHeader FromDTOToModel(mgmtHeaderDTO mgmtHeaderDTO)
        {
            return mgmtHeaderDTO != null ? new mgmtHeader.Builder(mgmtDetailDTO.FromDTOToModel(mgmtHeaderDTO.mgmt)).Build() : null;
        }
    }
}
