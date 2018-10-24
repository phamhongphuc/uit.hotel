using GraphQL;
using GraphQL.Types;
using uit.ooad.Queries;

namespace uit.ooad.Schemas
{
    /**
     * Để tiêm các services hoặc repositories vào các GraphQL Type
     * của chúng ta thì ta phải triển khai các interface đó ở đây
     *
     * Ý của nó là nó sẽ tiêm các services và repositories đã được
     * khai báo ở trong file startup.cs vào trong 2 class ở dưới
     *
     * Thật ra mình cũng không cần class này làm gì nhưng trong
     * hướng dẫn nói sao thì làm vậy thôi
     */
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}
