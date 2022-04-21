using Barbie.Core;

namespace Barbie.Repositories
{
    public interface IAllBarbie
    {
        public IEnumerable<Barbiee> MyProperty { get; set; }
        IEnumerable<Barbiee> Barbies { get; }
        IEnumerable<Barbiee> getFavBarbie { get; set; }
        Barbiee getObjectBarbie(int barbieId);

    }
}
