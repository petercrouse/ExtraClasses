using AutoMapper;
using ExtraClasses.Persistence;
using System;
using Xunit;

namespace ExtraClasses.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public ExtraClassesDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = ExtraClassesContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            ExtraClassesContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
