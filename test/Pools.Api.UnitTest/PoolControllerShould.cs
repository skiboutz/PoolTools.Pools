using Xunit;
using FluentAssertions;
using PoolTools.Pools.Api;

namespace Pools.Api.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnPoolList()
        {
            var controller = new PoolController();
            var poolList = controller.GetPools();

            poolList.Should().NotBeNull();

        }
    }
}
