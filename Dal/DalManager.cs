using Dal.Api;

using Dal.Services;
using Microsoft.Extensions.DependencyInjection;
using Dal.Models;
using Azure.Core;

namespace Dal
{
    public class DalManager:IDal
    {
        //dbcontext data=new dbcontext();
        public IDalCustomer Customer { get;  }
        public IdalInvestmentProvider InvestmentProvider{ get; }

        public IDalRequest RequestDetails{ get; }

        public IDalInvestment Investment  { get; }

    public DalManager() {

             


            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDalCustomer, DalCustomerService>();
            services.AddSingleton<IdalInvestmentProvider, DalInvestmentProviderService>();
            services.AddSingleton<IDalInvestment, DalInvestmentService>();
            services.AddSingleton<IDalRequest, DalRequestService>();

            services.AddSingleton<dbcontext, dbcontext>();
            ServiceProvider servicesProvider = services.BuildServiceProvider();


           // Customer = new DalCustomerService(data);
            Customer= servicesProvider.GetRequiredService<IDalCustomer>();
            InvestmentProvider = servicesProvider.GetRequiredService<IdalInvestmentProvider>();
            Investment = servicesProvider.  GetRequiredService <IDalInvestment>(); 
               
            RequestDetails = servicesProvider.GetRequiredService<IDalRequest>();


        }


    }
}