using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolateGQL.Context;
using HotChocolateGQL.GraphQLContext.Authors;
using HotChocolateGQL.GraphQLContext.Books;
using HotChocolateGQL.Models;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateGQL.GraphQLContext
{
    public class Mutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddAuthorPayload> AddAuthorPayloadAsync(AddAuthorInput input, 
            [ScopedService] ApplicationDbContext dbContext, 
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = input.Name,
                Age = input.age
            };


            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync(cancellationToken);

            //Executing the subscription
            await eventSender.SendAsync(nameof(Subscription.OnAuthorAdded), author, cancellationToken);

            return new AddAuthorPayload(author);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddBookPayload> AddBookAsync(AddBookInput input, [ScopedService] ApplicationDbContext dbContext)
        {
            var book = new Book
            {
                Name = input.Name,
                Description = input.Description,
                ReleaseYear = input.releaseYear,
                AuthorId = input.AuthorId
            };


            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return new AddBookPayload(book);
        }
    }
}
