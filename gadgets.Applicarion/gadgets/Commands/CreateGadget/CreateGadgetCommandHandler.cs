using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using gadgets.Application.Interfaces;
using gadgets.Domain;

namespace gadgets.Application.gadgets.Commands.CreateGadget
{
    public class CreateGadgetCommandHandler
        : IRequestHandler<CreateGadgetCommand, Guid>
    {
        private readonly IgadgetsDbContext _dbContext;
        public CreateGadgetCommandHandler(IgadgetsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateGadgetCommand request,
            CancellationToken cancellationToken)
        {
            var gadget = new gadget
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.gadgets.AddAsync(gadget, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return gadget.Id;
        }
    }
}
