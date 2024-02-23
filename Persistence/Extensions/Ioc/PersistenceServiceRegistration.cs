using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Extensions.Ioc;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ETrade")));
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IAdvertPhotoPathRepository, AdvertPhotoPathRepository>();
        services.AddScoped<IAdvertRepository, AdvertRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICorporateUserAdvertRepository, CorporateUserAdvertRepository>();
        services.AddScoped<ICorporateUserRepository, CorporateUserRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IIndividualUserAdvertRepository, IndividualUserAdvertRepository>();
        services.AddScoped<IIndividualUserRepository, IndividualUserRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserAddressRepository, UserAddressRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
