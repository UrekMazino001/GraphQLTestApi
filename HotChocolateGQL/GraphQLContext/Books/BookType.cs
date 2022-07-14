using HotChocolate;
using HotChocolate.Types;
using HotChocolateGQL.Context;
using HotChocolateGQL.Models;
using System.Linq;

namespace HotChocolateGQL.GraphQLContext.Books
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Description("Represents the Books");

            descriptor
                .Field(x => x.Author)
                .ResolveWith<Resolvers>(x => x.GetAuthor(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("This is the Autor of the book");
        }

        private class Resolvers
        {
            public Author GetAuthor(Book book, [ScopedService] ApplicationDbContext dbContext) => dbContext.Authors.FirstOrDefault(x => x.Id == book.AuthorId);
        }        
    }
}
