using System;
using gadgets.Persistance;

namespace gadgets.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly gadgetsDbContext Context;

        public TestCommandBase()
        {
            Context = gadgetsContextFactory.Create();
        }

        public void Dispose()
        {
            gadgetsContextFactory.Destroy(Context);
        }
    }
}
