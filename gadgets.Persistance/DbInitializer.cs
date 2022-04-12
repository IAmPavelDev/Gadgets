
namespace gadgets.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(gadgetsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
