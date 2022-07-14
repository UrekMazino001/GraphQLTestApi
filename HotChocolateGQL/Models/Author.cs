using HotChocolate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotChocolateGQL.Models
{

    //[GraphQLDescription("Represents the Authors ")]
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();    

    }
}
