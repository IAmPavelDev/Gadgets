using System;
using MediatR;
namespace gadgets.Application.gadgets.Queries.GetGadgetDetails
{
    public class GetGadgetDetailsQuery : IRequest<gadgetsDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id{ get; set; }
    }
}
