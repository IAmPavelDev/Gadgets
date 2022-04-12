using System;
using FluentValidation;

namespace gadgets.Application.gadgets.Queries.GetGadgetList
{
    public class GetGadgetListQueryValidator : AbstractValidator<GetGadgetListQuery>
    {
        public GetGadgetListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
