using AutoMapper;
using learn_Pokemon_Review_App.Dto;
using learn_Pokemon_Review_App.Models;

namespace learn_Pokemon_Review_App.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // FROM - TO
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}
