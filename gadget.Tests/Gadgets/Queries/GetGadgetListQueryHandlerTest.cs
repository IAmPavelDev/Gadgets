using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using gadgets.Application.gadgets.Queries.GetGadgetList;
using gadgets.Persistance;
using gadgets.Tests.Common;
using Shouldly;
using Xunit;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListQueryHandlerTests
    {
        private readonly gadgetsDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetGadgetListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetGadgetListQuery
                {
                    UserId = gadgetsContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GadgetListVm>();
            result.gadgets.Count.ShouldBe(2);
        }
    }
}