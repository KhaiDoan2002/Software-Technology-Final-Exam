using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class Accountant
    {
        public Accountant(string accountantId, string accountantName, string accountantPassword, int accountantAge, string accountantAddress)
        {
            AccountantId = accountantId;
            AccountantName = accountantName;
            AccountantPassword = accountantPassword;
            AccountantAge = accountantAge;
            AccountantAddress = accountantAddress;
        }

        public String AccountantId          { set; get; }
        public String AccountantName        { set; get; }

        public String AccountantPassword    { set; get; }
        public int AccountantAge            { set; get; }

        public String AccountantAddress     { set; get; }


    }
}
