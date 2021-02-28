using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorblueTechTask2.Repositories.Interfaces
{
    public interface IIpWhitelistRepository
    {
        Task<bool> GetIsIpWhitelistedAsync(string ipAddress);

        Task<List<string>> GetIpRangesAsync();
    }
}
