using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using gadgets.Application.Interfaces;

namespace gadgets.Application.gadgets.Queries.GetGadgetList
{
    public class GetGadgetListQueryHandler 
        : IRequestHandler<GetGadgetListQuery, GadgetListVm>
    {
        private readonly IgadgetsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGadgetListQueryHandler(IgadgetsDbContext dbContext,
            IMapper mapper) => 
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GadgetListVm> Handle(GetGadgetListQuery request,
            CancellationToken cancellationToken)
        {
            var gadgetsQuery = await _dbContext.gadgets
                .Where(gadget => gadget.UserId == request.UserId)
                .ProjectTo<GadgetLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new GadgetListVm { gadgets = gadgetsQuery };
        }
    }
}
