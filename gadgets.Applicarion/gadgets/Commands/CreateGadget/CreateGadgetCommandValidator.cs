using System;
using FluentValidation;

namespace gadgets.Application.gadgets.Commands.CreateGadget
{
    public class CreateGadgetCommandValidator : AbstractValidator<CreateGadgetCommand>
    {
        public CreateGadgetCommandValidator()
        {
            RuleFor(createGadgetCommand =>
                createGadgetCommand.Title).NotEmpty().MaximumLength(30);
            RuleFor(createGadgetCommand =>
                createGadgetCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
