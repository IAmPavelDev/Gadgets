using System;
using FluentValidation;

namespace gadgets.Application.gadgets.Commands.DeleteGadget
{
    public class DeleteGadgetCommandValidator : AbstractValidator<DeleteGadgetCommand>
    {
        public DeleteGadgetCommandValidator()
        {
            RuleFor(deleteGadgetCommand => deleteGadgetCommand.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(deleteGadgetCommand => deleteGadgetCommand.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
