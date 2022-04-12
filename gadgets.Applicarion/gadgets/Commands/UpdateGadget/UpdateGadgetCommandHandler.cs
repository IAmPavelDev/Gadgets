using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using gadgets.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using gadgets.Application.Common.Exceptions;
using gadgets.Domain;
namespace gadgets.Application.gadgets.Commands.UpdateGadget
{
    public class UpdateGadgetCommandHandler
        : IRequestHandler<UpdateGadgetCommand>
    {
        private readonly IgadgetsDbContext _dbContext;

        public UpdateGadgetCommandHandler(IgadgetsDbContext dbContext) => 
            _dbContext = dbContext;


        public async Task<Unit> Handle(UpdateGadgetCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.gadgets.FirstOrDefaultAsync(gadget => 
                gadget.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExceptions(nameof(gadget), request.Id);
            }
            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
