using learn_Pokemon_Review_App.Models;

namespace learn_Pokemon_Review_App.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        // Detail endpoint
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        bool CountryExists(int id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
