using System.Threading.Tasks;

namespace RazorblueTechTask2.Services.Interfaces
{
    public interface IIpWhitelistService
    {
        Task<bool> GetIsIpWhitelistedAsync(string ipAddress);
    }
}
