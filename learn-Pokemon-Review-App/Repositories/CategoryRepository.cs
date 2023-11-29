using learn_Pokemon_Review_App.Data;
using learn_Pokemon_Review_App.Interfaces;
using learn_Pokemon_Review_App.Models;

namespace learn_Pokemon_Review_App.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }
    }
}
