using Byteology.Abp.CreateTenantOnUser.Samples;
using Xunit;

namespace Byteology.Abp.CreateTenantOnUser.EntityFrameworkCore.Applications;

[Collection(CreateTenantOnUserTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<CreateTenantOnUserEntityFrameworkCoreTestModule>
{

}
