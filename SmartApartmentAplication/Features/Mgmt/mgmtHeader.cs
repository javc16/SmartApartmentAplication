using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Mgmt
{
    public class mgmtHeader
    {
        public int id { get; set; }
        public mgmtDetail mgmt { get; set; }
        public int isActive { get; set; }

        public sealed class Builder
        {
            private readonly mgmtHeader _mgmtHeader;

            public Builder(int id, mgmtDetail mgmt)
            {
                _mgmtHeader = new mgmtHeader
                {
                    id = id,
                    mgmt = mgmt,
                    isActive =1
                };
            }

          
            public mgmtHeader Build()
            {
                return _mgmtHeader;
            }
        }
    }
}
