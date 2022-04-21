using Barbie.Core;
using Barbie.Repositories;

namespace FirstStart.Data.mocks
{
    public class MokcBarbie : IAllBarbie
    {
        private readonly IBarbieCategory _categoryBarbie = new MockCategory();

        public IEnumerable<Barbie.Core.Barbie> MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<Barbie.Core.Barbie> Barbies => throw new NotImplementedException();

        public IEnumerable<Barbie.Core.Barbie> getFavBarbie { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Barbie.Core.Barbie getObjectBarbie(int barbieId)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Barbie.Core.Barbie> Barbies { 
        //    get
        //    {
        //        return new List<Barbie.Core.Barbie>
        //        {
        //        new Barbie.Core.Barbie { Name = "Barbie_Boy_Ivan", img = "https://i5.walmartimages.com/asr/018fb213-bbe9-4908-8dd0-473284f2dee3_1.7cde10b44e91d14426650fd035068767.jpeg", price = 1000, isFavourite = true, available = true, longDesc = "великий опис", shortDesc="Маленький опис", Category = _categoryBarbie.AllCategories.First() },
        //        new Barbie.Core.Barbie { Name = "Barbie_Girl_Oksana", img = "https://images.mattel.com/scene7/DGW37_01?$oslarge$&wid=412&hei=412&wid=1600&hei=1600", price = 1000, isFavourite = true, available = true, longDesc = "великий опис", shortDesc="Маленький опис", Category = _categoryBarbie.AllCategories.Last() }
        //        };
        //    } 
        //}
        //public IEnumerable<Barbie> getFavBarbie { get; set; }

        //public Barbie getObjectBarbie(int barbieId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
