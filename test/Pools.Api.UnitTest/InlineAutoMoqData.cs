using AutoFixture.Xunit2;

namespace Pools.Api.UnitTest
{
    public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] objects) : base(new AutoMoqDataAttribute(), objects) { }
}
}