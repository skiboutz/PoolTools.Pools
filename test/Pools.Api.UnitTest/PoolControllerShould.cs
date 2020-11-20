using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pools.Api.Data;
using Microsoft.AspNetCore.Http;
using Pools.Api.Controllers;
using AutoFixture;
using AutoFixture.AutoMoq;
using Pools.Api.Services;
using Moq;

namespace Pools.Api.UnitTest
{
    public class PoolControllerShould
    {
        [Fact]
        public async void ReturnPoolListAsync()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var moqRepository = new Mock<IPoolRepository>();
            var poolList = new List<Pool>();
            fixture.RepeatCount = 2;
            fixture.AddManyTo(poolList);
            moqRepository.Setup(r => r.GetAllPools()).ReturnsAsync(poolList);

            var controller = new PoolsController(moqRepository.Object);

            var result = await controller.GetPools();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Pool>>>(result);
            var poolListResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            poolListResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            var returnedPoolList = Assert.IsType<List<Pool>>(poolListResult.Value);
            returnedPoolList.Should().HaveCount(2);
        }
    }
}
