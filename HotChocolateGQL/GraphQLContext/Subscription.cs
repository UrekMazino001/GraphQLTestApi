using HotChocolate;
using HotChocolate.Types;
using HotChocolateGQL.Models;

namespace HotChocolateGQL.GraphQLContext
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Author OnAuthorAdded([EventMessage] Author author) => author;
    }
}
