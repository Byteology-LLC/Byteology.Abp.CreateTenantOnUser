using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Emailing;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Settings;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectMapping;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace Byteology.Abp.CreateTenantOnUser
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IAccountAppService), typeof(AccountAppService), typeof(CustomAccountAppService))]
    public class CustomAccountAppService : AccountAppService, ITransientDependency
    {
        private readonly IDataFilter _dataFilter;
        protected IDataSeeder DataSeeder { get; } 
        protected ITenantRepository TenantRepository { get; }
        protected ITenantManager TenantManager { get; }
        protected IDistributedEventBus DistributedEventBus { get; }
        protected IUnitOfWorkManager UnitOfWorkManager { get; } 


        public CustomAccountAppService(IdentityUserManager userManager, IIdentityRoleRepository roleRepository, IAccountEmailer accountEmailer, IdentitySecurityLogManager identitySecurityLogManager, IOptions<IdentityOptions> identityOptions, IDataFilter dataFilter, ITenantRepository tenantRepository, ITenantManager tenantManager, IDistributedEventBus distributedEventBus, IDataSeeder dataSeeder, IUnitOfWorkManager unitOfWorkManager) : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
        {
            _dataFilter = dataFilter;
            TenantRepository = tenantRepository;
            TenantManager = tenantManager;
            DistributedEventBus = distributedEventBus;
            DataSeeder = dataSeeder;
            UnitOfWorkManager = unitOfWorkManager;
        }

        public override async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            await CheckSelfRegistrationAsync();

            await IdentityOptions.SetAsync();

            //check uniqueness
            await ValidateUniqueEmailAsync(input.EmailAddress);

            //seed the user into a brand new tenant
            var tenant = await SeedNewTenantAsync(input);

            //if the seed is done correctly, we should now be able to pull the IdentityUser values from the user database and pass them back to the registration system
            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(await GetUserByEmailAddress(input.EmailAddress) ?? throw new InvalidOperationException());

        }

        private async Task<Tenant> SeedNewTenantAsync(RegisterDto input)
        {

            var uow = UnitOfWorkManager.Begin(requiresNew: true, isTransactional: true);

            //create a new tenant
            var tenant = await TenantManager.CreateAsync(input.EmailAddress);
            var test = await TenantRepository.InsertAsync(tenant, autoSave: true);

            //make sure the changes are saved to the database
            await uow.CompleteAsync();

            //public the event for event listeners
            await DistributedEventBus.PublishAsync(
                new TenantCreatedEto
                {
                    Id = tenant.Id,
                    Name = tenant.Name,
                    Properties =
                    {
                        { "AdminEmail", input.EmailAddress },
                        { "AdminPassword", input.Password }
                    }
                });


            uow = UnitOfWorkManager.Begin(requiresNew: true, isTransactional: true);
            //seed the admin user
            using (CurrentTenant.Change(tenant.Id, tenant.Name))
            {
                //TODO: Handle database creation?
                // TODO: Seeder might be triggered via event handler.
                await DataSeeder.SeedAsync(
                    new DataSeedContext(tenant.Id)
                        .WithProperty("AdminEmail", input.EmailAddress)
                        .WithProperty("AdminPassword", input.Password)
                );
            }

            await uow.CompleteAsync();

            return tenant;
        }



        private async Task ValidateUniqueEmailAsync(string emailAddress)
        {
            var user = await GetUserByEmailAddress(emailAddress);
            if (user != null)
            {
                throw new UserFriendlyException("Email address is already taken.");
            }
        }

        private async Task<IdentityUser?> GetUserByEmailAddress(string emailAddress)
        {
            //disable the IMultiTenant filter to allow for checking email address across all tenants
            using (_dataFilter.Disable<IMultiTenant>())
            {
                return await UserManager.FindByEmailAsync(emailAddress);
            }
        }

    }
}
