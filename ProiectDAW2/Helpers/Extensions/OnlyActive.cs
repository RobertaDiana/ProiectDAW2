using Demo.Models;

namespace Lab4_13.Helpers.Extensions
{
    public static class OnlyActive
    {
        public static IQueryable<Produse> GetActive(this IQueryable<Produse> entities)
        {
            return entities.Where(x => x.IsDeleted == false);
        }
    }
}
