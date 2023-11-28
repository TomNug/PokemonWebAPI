using learn_Pokemon_Review_App.Models;

namespace learn_Pokemon_Review_App.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
