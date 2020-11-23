using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Pools.Api.UnitTest
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture()
                .Customize(new ControllerBaseCustomization())
                .Customize(new AutoMoqCustomization()))
        {
        }
    }
}