﻿using Pager.UnitTests.Context;

namespace Pager.UnitTests.MockData
{
    public static class MockSeeder
    {
        public static void Seed(TestContext ctx, IEnumerable<IMockData> mocks)
        {
            foreach (var mock in mocks)
            {
                mock.Seed(ctx);
            }

            ctx.SaveChanges();
        }
    }
}
