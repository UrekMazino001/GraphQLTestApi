using System.ComponentModel.DataAnnotations;

namespace HotChocolateGQL.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        public int ReleaseYear { get; set; }


        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
