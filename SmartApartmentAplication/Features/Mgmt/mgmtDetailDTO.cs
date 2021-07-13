using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Mgmt
{
    public class mgmtDetailDTO
    {
        public int mgmtID { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public string state { get; set; }
        public static mgmtDetailDTO FromModelToDTO(mgmtDetail mgmtDetail)
        {
            return mgmtDetail != null ? new mgmtDetailDTO
            {
                mgmtID = mgmtDetail.mgmtID,
                name = mgmtDetail.name,
                market = mgmtDetail.market,
                state = mgmtDetail.state
            } : null;
        }

        public static IEnumerable<mgmtDetailDTO> FromModelToDTO(IEnumerable<mgmtDetail> mgmtDetail)
        {
            if (mgmtDetail == null)
            {
                return new List<mgmtDetailDTO>();
            }
            List<mgmtDetailDTO> mgmtDetailData = new List<mgmtDetailDTO>();

            foreach (var item in mgmtDetail)
            {
                mgmtDetailData.Add(FromModelToDTO(item));
            }

            return mgmtDetailData;
        }


        public static mgmtDetail FromDTOToModel(mgmtDetailDTO mgmtDetailDTO)
        {
            return mgmtDetailDTO != null ? new mgmtDetail.Builder(mgmtDetailDTO.mgmtID,mgmtDetailDTO.name, mgmtDetailDTO.market, mgmtDetailDTO.state).Build() : null;
        }
    }

    

    
}
