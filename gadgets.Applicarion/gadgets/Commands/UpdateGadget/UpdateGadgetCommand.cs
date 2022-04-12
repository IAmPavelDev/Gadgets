using System;
using MediatR;
namespace gadgets.Application.gadgets.Commands.UpdateGadget
{
    public class UpdateGadgetCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
