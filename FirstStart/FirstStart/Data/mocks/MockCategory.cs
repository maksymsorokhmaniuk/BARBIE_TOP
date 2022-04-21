using Barbie.Repositories;
using Barbie.Core;

namespace FirstStart.Data.mocks
{
    public class MockCategory : IBarbieCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Barbie BOY", Desc = "Барби з коротким волоссям і сильними м'язами"},
                    new Category { CategoryName = "Barbie GIRL", Desc = "Барбі з довгим волосям та слабкими м'язами" }
                };
            }
        }
    }
}
