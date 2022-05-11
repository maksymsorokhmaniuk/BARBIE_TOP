using Barbie.Core;
using Barbie.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Barbie.Repositories
{
    public class BarbieRepository : IBarbieRepository
    {
        private readonly ApplicationDbContext context;

        public BarbieRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public void AddBarbie(Barbiee barbie)
        {
            context.Add(barbie);
            context.SaveChanges();
        }

        public IEnumerable<Barbiee> AllBarbies()
        {
            return context.Barbies.Include(x => x.Category).ToList();
        }

        public void DeleteBarbie(int id)
        {
            context.Remove(GetBarbieById(id));
            context.SaveChanges();
        }

        public IEnumerable<Barbiee> FindBarbie(string text)
        {
            return context.Barbies.Include(x => x.Category).Where(x => x.Name.Contains(text) || x.Description.Contains(text)).ToList();
        }

        public Barbiee GetBarbieById(int id)
        {
            return context.Barbies.Find(id);
        }

        public IEnumerable<Barbiee> GetBarbiesByCategory(int id)
        {
            return context.Barbies.Include(x => x.Category).Where(x => x.CategoryID == id).ToList();
        }

        public void UpdateBarbie(int id, Barbiee model)
        {
            var barbie = GetBarbieById(id);

            if (barbie.Name != model.Name)
            {
                barbie.Name = model.Name;
            }
            if (barbie.Description != model.Description)
            {
                barbie.Description = model.Description;
            }
            if (barbie.CategoryID != model.CategoryID)
            {
                barbie.CategoryID = model.CategoryID;
            }
            if (barbie.Username != model.Username)
            {
                barbie.Username = model.Username;
            }
            if (barbie.Img != model.Img)
            {
                if (model.Img != "noPhoto.jpg")
                {
                    barbie.Img = model.Img;
                }
            }

            context.Update(barbie);
            context.SaveChanges();
        }
    }
}
