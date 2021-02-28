using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorblueTechTask2.Repositories.Interfaces;

namespace RazorblueTechTask2.Repositories
{
    // repository class fakes database access
    // would likely store the whitelisted ip in cosmosDb as it's a simple object
    // will implement if time allows
    public class IpWhitelistRepository : IIpWhitelistRepository
    {
        private readonly List<string> _ipRanges = new List<string>
        {
            "192.168.1.0/24",
            "192.168.1.240",
            "172.169.0.0-192.169.0.255",
            "168.177.1.1",
            "154.1.0.1/24",
            "2.6.1.9-91.17.14.5"
        };

        public async Task<List<string>> GetIpRangesAsync()
        {
            return await Task.FromResult(_ipRanges.Where(x => x.Contains("/") || x.Contains("-")).ToList());
        }

        public async Task<bool> GetIsIpWhitelistedAsync(string ipAddress)
        {
            return await Task.FromResult(_ipRanges.Any(x => x.Equals(ipAddress)));
        }
    }
}
