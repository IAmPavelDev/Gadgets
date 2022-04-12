using System;
using Microsoft.EntityFrameworkCore;
using gadgets.Domain;
using gadgets.Persistance;
namespace gadgets.Tests.Common
{
    public class gadgetsContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid GadgetIdForDelete = Guid.NewGuid();
        public static Guid GadgetIdForUpdate = Guid.NewGuid();

        public static gadgetsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<gadgetsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new gadgetsDbContext(options);
            context.Database.EnsureCreated();
            context.gadgets.AddRange(
                new Domain.gadget
                {
                    CreationDate = DateTime.Today,
                    Details = "Detail1",
                    EditDate = null,
                    Id = Guid.Parse("{F7ABCCD1-6828-4361-818C-C88EC80147E5}"),
                    Title = "Title1",
                    UserId = UserAId
                },
                new Domain.gadget
                {
                CreationDate = DateTime.Today,
                    Details = "Detail2",
                    EditDate = null,
                    Id = Guid.Parse("{{E875889E-E750-4DD7-B77A-6B74AB662629}}"),
                    Title = "Title2",
                    UserId = UserBId
                },
                new Domain.gadget
                {
                    CreationDate = DateTime.Today,
                    Details = "Detail3",
                    EditDate = null,
                    Id = GadgetIdForDelete,
                    Title = "Title3",
                    UserId = UserAId
                },
                new Domain.gadget
                {
                    CreationDate = DateTime.Today,
                    Details = "Detail4",
                    EditDate = null,
                    Id = GadgetIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(gadgetsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
