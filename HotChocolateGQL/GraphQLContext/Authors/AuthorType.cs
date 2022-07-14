using HotChocolate;
using HotChocolate.Types;
using HotChocolateGQL.Context;
using HotChocolateGQL.Models;
using System.Linq;

namespace HotChocolateGQL.GraphQLContext.Authors
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Description("Represents the Authors");

            descriptor
                .Field(x => x.Age).Ignore();
                
            descriptor
                .Field(x => x.Books)
                .ResolveWith<Resolvers>(x => Resolvers.GetBooks(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("This is the list of available books");
        }

        private class Resolvers
        {
            public static IQueryable<Book> GetBooks(Author author, [ScopedService] ApplicationDbContext dbContext)
            {
                return dbContext.Books.Where(x => x.AuthorId == author.Id);
            }
        }
    }
}
