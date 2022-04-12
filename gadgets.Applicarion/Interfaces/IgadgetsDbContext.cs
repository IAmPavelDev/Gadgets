using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gadgets.Domain;

namespace gadgets.Application.Interfaces
{
    public interface IgadgetsDbContext
    {
        DbSet<gadget> gadgets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}