using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NetTools;
using RazorblueTechTask2.Repositories.Interfaces;
using RazorblueTechTask2.Services.Interfaces;

namespace RazorblueTechTask2.Services
{
    // using a service/ repository layout to complete business logic within the service class
    public class IpWhitelistService : IIpWhitelistService
    {
        private readonly IIpWhitelistRepository _repository;

        public IpWhitelistService(IIpWhitelistRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> GetIsIpWhitelistedAsync(string ip)
        {
            // we'll do a simple linq search against the reponse to begin with
            // if I have time to implement a database, this can be changed to a SELECT FROM query.
            bool ipWhitelisted = await _repository.GetIsIpWhitelistedAsync(ip);

            // if at this point the function returns true, the ip is whitelisted and we can return the response
            if (ipWhitelisted)
            {
                return ipWhitelisted;
            }

            // at this point, the above check returned false, so we can query the data source again
            // however, we will only return options that either match CIDR notation or are stored as a range of IPs
            List<string> ipRanges = await _repository.GetIpRangesAsync();
            List<IPAddressRange> ipAddressRanges = new List<IPAddressRange>();
            IPAddress ipAddress = IPAddress.Parse(ip);

            ipRanges.ForEach(ipRange =>
            {
                ipAddressRanges.Add(IPAddressRange.Parse(ipRange));
            });

            return ipAddressRanges.Any(x => x.Contains(ipAddress));
        }
    }
}
