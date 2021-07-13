using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Property
{
    public class propertyHeaderDTO
    {
        public propertyDetailDTO property { get; set; }

        public static propertyHeaderDTO FromModelToDTO(propertyHeader propertyHeader)
        {

            return propertyHeader != null ? new propertyHeaderDTO
            {
                property = propertyDetailDTO.FromModelToDTO(propertyHeader.property)
            } : null;
        }

        public static IEnumerable<propertyHeaderDTO> FromModelToDTO(IEnumerable<propertyHeader> propertyHeader)
        {
            if (propertyHeader == null)
            {
                return new List<propertyHeaderDTO>();
            }
            List<propertyHeaderDTO> propertyHeaderData = new List<propertyHeaderDTO>();

            foreach (var item in propertyHeader)
            {
                propertyHeaderData.Add(FromModelToDTO(item));
            }

            return propertyHeaderData;
        }


        public static propertyHeader FromDTOToModel(propertyHeaderDTO propertyHeaderDTO)
        {
            return propertyHeaderDTO != null ? new propertyHeader.Builder(propertyDetailDTO.FromDTOToModel(propertyHeaderDTO.property)).Build() : null;
        }
    }
}
