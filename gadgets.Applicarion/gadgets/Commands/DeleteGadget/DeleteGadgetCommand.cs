using System;
using MediatR;
namespace gadgets.Application.gadgets.Commands.DeleteGadget
{
    public class DeleteGadgetCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
