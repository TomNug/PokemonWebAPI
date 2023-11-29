using AutoMapper;
using learn_Pokemon_Review_App.Dto;
using learn_Pokemon_Review_App.Interfaces;
using learn_Pokemon_Review_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace learn_Pokemon_Review_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        
        // Inject repository into controller
        public CategoryController(ICategoryRepository categoryReposity, IMapper mapper)
        {
            _categoryRepository = categoryReposity;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);
        }


        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoryDto>(
                _categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }


        [HttpGet("pokemon/{categoryId}")] // api endpoint
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonByCategoryId(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(
                _categoryRepository.GetPokemonByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(pokemons);
        }

    }
}
