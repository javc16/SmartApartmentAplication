using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.Features.Mgmt
{
    public class mgmtDetail
    {
        public int id { get; set; }
        public int mgmtID { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public string state { get; set; }
        public int isActive { get; set; }


        public sealed class Builder
        {
            private readonly mgmtDetail _mgmtDetail;

            public Builder(int mgmtID,string name, string market,string state)
            {
                _mgmtDetail = new mgmtDetail
                {
                   mgmtID = mgmtID,
                   name = name,
                   market = market,
                   state = state,
                   isActive =1
                };
            }


            public mgmtDetail Build()
            {
                return _mgmtDetail;
            }
        }
    }
}
