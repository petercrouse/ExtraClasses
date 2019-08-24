using ExtraClasses.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

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
