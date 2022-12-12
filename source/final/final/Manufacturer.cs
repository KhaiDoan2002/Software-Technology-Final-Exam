using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class Manufacturer
    {
        public Manufacturer(string ManuID, string ManuName, string address)
        {
            ManufacturerId = ManuID;
            ManufacturerName = ManuName;
            Address = address;
        }

        public string ManufacturerId { set; get; }
        public string ManufacturerName { set; get; }
        public string Address { set; get;  }
    }
}
