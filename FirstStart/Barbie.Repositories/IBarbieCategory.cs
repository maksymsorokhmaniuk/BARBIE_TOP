using Barbie.Core;

namespace Barbie.Repositories
{
    public interface IBarbieCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
