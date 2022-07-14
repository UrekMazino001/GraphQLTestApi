using HotChocolateGQL.Models;

namespace HotChocolateGQL.GraphQLContext.Books
{
    public record AddBookInput(string Name, string Description, int releaseYear, int AuthorId);
    public record AddBookPayload(Book book);
}
