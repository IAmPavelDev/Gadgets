using System;
using MediatR;
namespace gadgets.Application.gadgets.Commands.CreateGadget
{
    public class CreateGadgetCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
