using ExtraClasses.Application.Subjects.Queries.GetSubjects;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Subjects.Queries
{
    [Collection("QueryCollection")]
    public class GetSubjectListQueryHandlerTests
    {

        private readonly ExtraClassesDbContext _context;

        public GetSubjectListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetSubjectList()
        {
            var sut = new GetSubjectsQueryHandler(_context);

            var result = await sut.Handle(new GetSubjectListQuery(), CancellationToken.None);

            result.ShouldBeOfType<SubjectListViewModel>();

            result.Subjects.Count().ShouldBe(2);
        }

    }
}
