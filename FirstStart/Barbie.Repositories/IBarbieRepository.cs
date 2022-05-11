using Barbie.Core;

namespace Barbie.Repositories
{
    public interface IBarbieRepository
    {
        public IEnumerable<Barbiee> AllBarbies();
        public void AddBarbie(Barbiee barbie);
        public void UpdateBarbie(int id, Barbiee model);
        public void DeleteBarbie(int id);
        public Barbiee GetBarbieById(int id);
        public IEnumerable<Barbiee> GetBarbiesByCategory(int id);
        public IEnumerable<Barbiee> FindBarbie(string text);
    }
}
