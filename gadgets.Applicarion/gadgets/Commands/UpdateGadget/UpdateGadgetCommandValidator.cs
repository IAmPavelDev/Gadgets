using System;
using FluentValidation;

namespace gadgets.Application.gadgets.Commands.UpdateGadget
{
    public class UpdateGadgetCommandValidator : AbstractValidator<UpdateGadgetCommand>
    {
        public UpdateGadgetCommandValidator()
        {
            RuleFor(updateGadgetCommand => updateGadgetCommand.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(updateGadgetCommand => updateGadgetCommand.Id)
                .NotEqual(Guid.Empty);
            RuleFor(updateGadgetCommand => updateGadgetCommand.Title)
                .NotEmpty()
                .MaximumLength(30);
        }
    }
}
