using gadgets.Application.gadgets.Commands.CreateGadget;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using gadgets.Tests.Common;
using Xunit;
namespace gadgets.Tests.Gadgets.Commands
{
    public class CreateGadgetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateGadgetCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateGadgetCommandHandler(Context);
            var gadgetName = "gagdet name";
            var gadgetDatails = "gadget datails";

            //Act
            var gadgetId = await handler.Handle(
                new CreateGadgetCommand
                {
                    Title = gadgetName,
                    Details = gadgetDatails,
                    UserId = gadgetsContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.gadgets.SingleOrDefaultAsync(
                    gadget => gadget.Id == gadgetId && gadget.Title == gadgetName &&
                              gadget.Details == gadgetDatails));
        }
    }
}
