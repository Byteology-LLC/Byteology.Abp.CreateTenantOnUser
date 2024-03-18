using Byteology.Abp.CreateTenantOnUser.Samples;
using Xunit;

namespace Byteology.Abp.CreateTenantOnUser.EntityFrameworkCore.Domains;

[Collection(CreateTenantOnUserTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<CreateTenantOnUserEntityFrameworkCoreTestModule>
{

}
