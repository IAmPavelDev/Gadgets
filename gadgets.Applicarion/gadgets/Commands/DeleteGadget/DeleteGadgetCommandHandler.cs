using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using gadgets.Application.Interfaces;
using gadgets.Application.Common.Exceptions;
using gadgets.Domain;
namespace gadgets.Application.gadgets.Commands.DeleteGadget
{
    public  class DeleteGadgetCommandHandler
        : IRequest<DeleteGadgetCommand>
    {
        private readonly IgadgetsDbContext _dbContext;
        public DeleteGadgetCommandHandler(IgadgetsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteGadgetCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.gadgets
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExceptions(nameof(gadget), request.Id);
            }
            _dbContext.gadgets.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
