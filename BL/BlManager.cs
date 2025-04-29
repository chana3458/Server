using BL.Api;
using BL.Services;
using Dal;
using Dal.Api;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class BlManager : IBL
    {
        public IblCustomer Customer { get; }

        public IblInvestmentProvider InvestmentProvider { get; }

        public IblRequest Request { get; }

        public IblInvestment Investment  {get;}

        public BlManager()
        {
          
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<IblCustomer, BlCustomerService>();
            services.AddSingleton<IblInvestmentProvider, BlInvestmentProviderService>();
            services.AddSingleton<IblInvestment, BlInvestmentService>();
            services.AddSingleton<IblRequest, BlRequestService>();

            ServiceProvider servicesProvider = services.BuildServiceProvider();

            Customer = servicesProvider.GetRequiredService<IblCustomer>();

            Investment = servicesProvider.GetRequiredService<IblInvestment>();

            InvestmentProvider = servicesProvider.GetRequiredService<IblInvestmentProvider>();

            Request=servicesProvider.GetRequiredService<IblRequest>();

        }


    }
}