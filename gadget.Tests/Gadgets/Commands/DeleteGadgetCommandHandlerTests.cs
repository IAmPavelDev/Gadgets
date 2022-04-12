using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using gadgets.Application.Common.Exceptions;
using gadgets.Application.gadgets.Commands.DeleteGadget;
using gadgets.Application.gadgets.Commands.CreateGadget;
using gadgets.Tests.Common;
using Xunit;

namespace gadgets.Tests.Gadgets.Commands
{
    public class DeleteGadgetCommandHandlerTests : TestCommandBase
    {
        public async Task DeleteGadgetCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteGadgetCommandHandler(Context);

            //Act
            await handler.Handle(
                new DeleteGadgetCommand
                {
                    Id = gadgetsContextFactory.GadgetIdForDelete,
                    UserId = gadgetsContextFactory.GadgetIdForDelete,

                }, CancellationToken.None);

            //Assert
            Assert.Null(Context.gadgets.SingleOrDefault(
                gadget => gadget.Id == gadgetsContextFactory.GadgetIdForDelete));
        }

        [Fact]
        public async Task DeleteGadgetCommandHandler_FailOrWrongId()
        {
            //Arrange
            var handler = new DeleteGadgetCommandHandler(Context);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
                await handler.Handle(
                    new DeleteGadgetCommand
                    {
                        Id= Guid.NewGuid(),
                        UserId = gadgetsContextFactory.UserAId,

                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteGadgetCommandHandler_FailOrWrongUserId()
        {
            //Arrange
            var deleteHandler = new DeleteGadgetCommandHandler(Context);
            var createHandler = new CreateGadgetCommandHandler(Context);
            var gadgetId = await createHandler.Handle(
                new CreateGadgetCommand
                {
                    Title = "gadget title",
                    UserId = gadgetsContextFactory.UserAId
                }, CancellationToken.None);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
                await deleteHandler.Handle(
                    new DeleteGadgetCommand
                    {
                        Id = gadgetId,
                        UserId = gadgetsContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
