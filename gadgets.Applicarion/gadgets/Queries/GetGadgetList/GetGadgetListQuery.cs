using System;
using MediatR;
namespace gadgets.Application.gadgets.Queries.GetGadgetList
{
    public class GetGadgetListQuery : IRequest<GadgetListVm>
    {
        public Guid UserId { get; set; }
    }
}
