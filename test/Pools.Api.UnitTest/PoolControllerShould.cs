using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pools.Api.Data;
using Microsoft.AspNetCore.Http;
using Pools.Api.Controllers;
using Moq;
using Pools.Api.Services;
using AutoFixture.Xunit2;
using AutoFixture;

namespace Pools.Api.UnitTest
{
    public class PoolControllerShould
    {
        [Theory, AutoMoqData]
        public async void ReturnPoolListAsync([Frozen] Mock<IPoolRepository> mockRepository, IFixture fixture, PoolsController sut)
        {
            List<Pool> pools = GivenTestPools(fixture);
            mockRepository.Setup(r => r.GetAllPools()).ReturnsAsync(pools);

            var result = await sut.GetPools();
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Pool>>>(result);
            var poolListResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            poolListResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            var returnedPoolList = Assert.IsType<List<Pool>>(poolListResult.Value);
            returnedPoolList.Should().HaveCount(2);
        }

        private static List<Pool> GivenTestPools(IFixture fixture)
        {
            var pools = new List<Pool>();
            fixture.RepeatCount = 2;
            fixture.AddManyTo(pools);
            return pools;
        }

        [Theory]
        [InlineAutoMoqData(2,true)]
        [InlineAutoMoqData(1,false)]
        public async void ReturnPoolById(int poolId, bool poolFound, [Frozen] Mock<IPoolRepository> mockRepository, IFixture fixture, PoolsController sut)
        {
            mockRepository.Setup(r => r.GetPoolById(It.Is<int>(i => i % 2 == 0))).ReturnsAsync(fixture.Build<Pool>().With(p => p.Id, poolId).Create());
            mockRepository.Setup(r => r.GetPoolById(It.Is<int>(i => i % 2 != 0))).ReturnsAsync((Pool)null);

            var result = await sut.GetPool(poolId);
            if (poolFound)
            {
                var actionResult = Assert.IsType<ActionResult<Pool>>(result);
                var poolResult = Assert.IsType<OkObjectResult>(actionResult.Result);
                poolResult.StatusCode.Should().Be(StatusCodes.Status200OK);

                var returnedPool = Assert.IsType<Pool>(poolResult.Value);
                returnedPool.Id.Should().Be(poolId);
            }
            else
            {
                var actionResult = Assert.IsType<ActionResult<Pool>>(result);
                var poolResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
                poolResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
            }
        }
    }
}
