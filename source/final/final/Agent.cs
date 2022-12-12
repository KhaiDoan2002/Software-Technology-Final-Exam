using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class Agent
    {
        public Agent(string agentId, string agentName, string agentPassword, string agentAddress)
        {
            AgentId = agentId;
            AgentName = agentName;
            AgentPassword = agentPassword;
            AgentAddress = agentAddress;
        }

        public String AgentId { set; get; }
        public String AgentName { set; get; }

        public String AgentPassword { set; get; }

        public String AgentAddress { set; get; }
    }
}
