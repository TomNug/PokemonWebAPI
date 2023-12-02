using learn_Pokemon_Review_App.Data;
using learn_Pokemon_Review_App.Interfaces;
using learn_Pokemon_Review_App.Models;

namespace learn_Pokemon_Review_App.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(
                o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            // Need select/include
            // Entity framework does not bring in navigation properties
            return _context.PokemonOwners.Where(
                p => p.Pokemon.Id == pokeId)
                .Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(
                o => o.OwnerId == ownerId)
                .Select(p => p.Pokemon).ToList();
        } // Potential error, changed o to p

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }
    }
}
