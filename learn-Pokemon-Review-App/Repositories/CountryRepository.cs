using AutoMapper;
using learn_Pokemon_Review_App.Data;
using learn_Pokemon_Review_App.Interfaces;
using learn_Pokemon_Review_App.Models;

namespace learn_Pokemon_Review_App.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CountryRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            // Bring in data context
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Remove(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.
                Where(o => o.Id == ownerId)
                .Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }
    }
}
