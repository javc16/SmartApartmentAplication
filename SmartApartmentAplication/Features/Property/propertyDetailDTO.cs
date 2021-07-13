using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Property
{
    public class propertyDetailDTO
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public string formerName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string market { get; set; }
        public string state { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }

        public static propertyDetailDTO FromModelToDTO(propertyDetail propertyDetail)
        {
            return propertyDetail != null ? new propertyDetailDTO
            {
                propertyID = propertyDetail.propertyID,
                name = propertyDetail.name,
                formerName = propertyDetail.formerName,
                streetAddress = propertyDetail.streetAddress,
                city = propertyDetail.city,
                market = propertyDetail.market,
                state = propertyDetail.state,
                lat = propertyDetail.lat,
                lng = propertyDetail.lng
            } : null;
        }

        public static IEnumerable<propertyDetailDTO> FromModelToDTO(IEnumerable<propertyDetail> propertyDetail)
        {
            if (propertyDetail == null)
            {
                return new List<propertyDetailDTO>();
            }
            List<propertyDetailDTO> propertyDetailData = new List<propertyDetailDTO>();

            foreach (var item in propertyDetail)
            {
                propertyDetailData.Add(FromModelToDTO(item));
            }

            return propertyDetailData;
        }


        public static propertyDetail FromDTOToModel(propertyDetailDTO propertyDetailDTO)
        {
            return propertyDetailDTO != null ? new propertyDetail.Builder(propertyDetailDTO.propertyID,propertyDetailDTO.name,propertyDetailDTO.formerName,
                propertyDetailDTO.streetAddress,propertyDetailDTO.city,propertyDetailDTO.market,propertyDetailDTO.state,propertyDetailDTO.lat,propertyDetailDTO.lng).Build() : null;
        }
    }
}
