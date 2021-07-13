using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Property
{
    public class propertyHeader
    {
        public int id { get; set; }
        public propertyDetail property { get; set; }
        public int isActive { get; set; }

        public sealed class Builder
        {
            private readonly propertyHeader _propertyHeader;

            public Builder(propertyDetail property)
            {
                _propertyHeader = new propertyHeader
                {
                    property = property,
                    isActive = 1
                };
            }


            public propertyHeader Build()
            {
                return _propertyHeader;
            }
        }
    }


   
}
