using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using gadgets.Application.gadgets.Queries.GetGadgetDetails;
using gadgets.Persistance;
using gadgets.Tests.Common;
using Shouldly;
using Xunit;

namespace gadgets.Tests.Gadgets.Queries
{
    public class GetGadgetDetailsQueryHandlerTests
    {
        [Collection("QueryCollection")]
        public class GetNoteDetailsQueryHandlerTests
        {
            private readonly gadgetsDbContext Context;
            private readonly IMapper Mapper;

            public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
            {
                Context = fixture.Context;
                Mapper = fixture.Mapper;
            }

            [Fact]
            public async Task GetNoteDetailsQueryHandler_Success()
            {
                // Arrange
                var handler = new GetGadgetDetailsQueryHandler(Context, Mapper);

                // Act
                var result = await handler.Handle(
                    new GetGadgetDetailsQuery
                    {
                        UserId = gadgetsContextFactory.UserBId,
                        Id = Guid.Parse("E875889E-E750-4DD7-B77A-6B74AB662629")
                    },
                    CancellationToken.None);

                // Assert
                result.ShouldBeOfType<gadgetsDetailsVm>();
                result.Title.ShouldBe("Title2");
                result.CreationDate.ShouldBe(DateTime.Today);
            }
        }
    }
}
