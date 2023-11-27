namespace learn_Pokemon_Review_App.Models
{
    public class PokemonCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
