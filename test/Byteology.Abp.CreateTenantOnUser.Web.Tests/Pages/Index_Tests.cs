using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Byteology.Abp.CreateTenantOnUser.Pages;

public class Index_Tests : CreateTenantOnUserWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
