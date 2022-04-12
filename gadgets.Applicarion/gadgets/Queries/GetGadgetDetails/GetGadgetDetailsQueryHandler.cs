using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using System.Threading;
using gadgets.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using gadgets.Application.Common.Exceptions;
using gadgets.Domain;
namespace gadgets.Application.gadgets.Queries.GetGadgetDetails
{
    public class GetGadgetDetailsQueryHandler
        :IRequestHandler<GetGadgetDetailsQuery, gadgetsDetailsVm>
    {
        private readonly IgadgetsDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGadgetDetailsQueryHandler(IgadgetsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<gadgetsDetailsVm> Handle(GetGadgetDetailsQuery request,
               CancellationToken cancellationToken)
        {
            var entity  = await _dbContext.gadgets
                .FirstOrDefaultAsync(gadget
                => gadget.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExceptions(nameof(gadget), request.Id);
            }
            return _mapper.Map<gadgetsDetailsVm>(entity);
        }
    }
}