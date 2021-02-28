using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RazorblueTechTask2.Repositories;
using RazorblueTechTask2.Repositories.Interfaces;
using RazorblueTechTask2.Services;
using RazorblueTechTask2.Services.Interfaces;

namespace RazorblueTechTask2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = SetupDI();

            var service = services.GetService<IIpWhitelistService>();

            Console.WriteLine("Please enter an IPv4 address to check");
            var ipToCheck = Console.ReadLine();

            switch (await service.GetIsIpWhitelistedAsync(ipToCheck))
            {
                case true:
                    Console.WriteLine($"{ipToCheck} is whitelisted");
                    break;
                default:
                    Console.WriteLine($"{ipToCheck} is not whitelisted");
                    break;
            }

            Console.ReadKey();
        }

        static ServiceProvider SetupDI()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IIpWhitelistRepository, IpWhitelistRepository>();
            services.AddSingleton<IIpWhitelistService, IpWhitelistService>();

            return services.BuildServiceProvider();
        }
    }
}
