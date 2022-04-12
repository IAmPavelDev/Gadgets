using System;
using System.Threading;
using System.Threading.Tasks;
using gadgets.Application.Common.Exceptions;
using gadgets.Application.gadgets.Commands.UpdateGadget;
using gadgets.Tests.Common;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace gadgets.Tests.Gadgets.Commands
{
    public class UpdateGadgetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateGadgetCommandHandler(Context);
            var updatedTitle = "new title";

            // Act
            await handler.Handle(new UpdateGadgetCommand
            {
                Id = gadgetsContextFactory.GadgetIdForUpdate,
                UserId = gadgetsContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.gadgets.SingleOrDefaultAsync(note =>
                note.Id == gadgetsContextFactory.GadgetIdForUpdate &&
                note.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateGadgetCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
                await handler.Handle(
                    new UpdateGadgetCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = gadgetsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateGadgetCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
            {
                await handler.Handle(
                    new UpdateGadgetCommand
                    {
                        Id = gadgetsContextFactory.GadgetIdForUpdate,
                        UserId = gadgetsContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}