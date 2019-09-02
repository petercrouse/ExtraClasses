using ExtraClasses.Persistence;
using System;

namespace ExtraClasses.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ExtraClassesDbContext _context;

        public CommandTestBase()
        {
            _context = ExtraClassesContextFactory.Create();
        }

        public void Dispose()
        {
            ExtraClassesContextFactory.Destroy(_context);
        }
    }
}
