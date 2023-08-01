using Business.Layer.Services.Contracts;
using Business.Layer.Services;
using DataAccess.Layer.Repositories.Contracts;
using DataAccess.Layer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DependencyInjenction
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>(s =>
            {
                var httpClient = new HttpClient();
                // Configurer le HttpClient ici si nécessaire
                return httpClient;
            });
               services.AddScoped<IDossierRepository, DossierRepository>();
               services.AddScoped<IDossierService, DossierService>();

               services.AddScoped<IPurchaseInvoiceServicecs, purchaseInvoiceService>();
               services.AddScoped<IPurchaseInvoiceRepository, PurchaseInvoiceRepository>();

               services.AddScoped<IsalesInvoiceRepository, SalesInvoicesRepository>();
               services.AddScoped<ISalesInvoiceService, SalesInvoiceService>();
            
            return services;
        }
    }
}
