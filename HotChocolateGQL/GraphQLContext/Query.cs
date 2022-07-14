using HotChocolate;
using HotChocolate.Data;
using HotChocolateGQL.Context;
using HotChocolateGQL.Models;
using System.Linq;

namespace HotChocolateGQL.GraphQLContext
{
    public class Query
    {


        //public IQueryable<Author> GetAuthors([Service] ApplicationDbContext dbContext) => dbContext.Authors;
        [UseDbContext(typeof(ApplicationDbContext))]
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors([ScopedService] ApplicationDbContext dbContext) => dbContext.Authors;


        [UseDbContext(typeof(ApplicationDbContext))]
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] ApplicationDbContext dbContext) => dbContext.Books;
    }
}
