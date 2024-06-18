using Pager.UnitTests.Context;

namespace Pager.UnitTests.MockData
{
    public interface IMockData
    {
        public void Seed(TestContext db);
    }
}
