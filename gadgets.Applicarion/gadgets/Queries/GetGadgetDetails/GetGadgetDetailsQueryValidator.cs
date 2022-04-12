using System;
using FluentValidation;

namespace gadgets.Application.gadgets.Queries.GetGadgetDetails
{
    public class GetGadgetDetailsQueryValidator : AbstractValidator<GetGadgetDetailsQuery>
    {
        public GetGadgetDetailsQueryValidator()
        {
            RuleFor(gadget => gadget.Id).NotEqual(Guid.Empty);
            RuleFor(gadget => gadget.UserId).NotEqual(Guid.Empty);
        }
    }
}
