using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Property
{
    public class propertyDetail
    {
        public int id { get; set; }
        public int propertyID { get; set; }
        public string name { get; set; }
        public string formerName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string market { get; set; }
        public string state { get; set; }

        public float lat { get; set; }
        public float lng { get; set; }
        public int isActive { get; set; }

        public sealed class Builder
        {
            private readonly propertyDetail _propertyDetail;

            public Builder(int propertyID, string name, string formerName,string streetAddress,string city,string market, string state, float lat, float lng)
            {
                _propertyDetail = new propertyDetail
                {
                    propertyID = propertyID,
                    name = name,
                    formerName = formerName,
                    streetAddress = streetAddress,
                    city = city,
                    market = market,
                    state = state,
                    lat = lat,
                    lng = lng,
                    isActive = 1
                };
            }


            public propertyDetail Build()
            {
                return _propertyDetail;
            }
        }
    }


}
