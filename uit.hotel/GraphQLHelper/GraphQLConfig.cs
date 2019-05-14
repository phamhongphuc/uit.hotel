using System;
using GraphQL;
using GraphQL.Authorization;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries;
using uit.hotel.Schemas;

namespace uit.hotel.GraphQLHelper
{
    public static class GraphQLConfig
    {
        public static IServiceCollection AddGraphQL(this IServiceCollection services)
        {
            return services
                .AddInputType()
                .AddObjectType()
                .AddSchema()
                .AddResolver()
                .AddDataLoader()
                .AddAuthorization();
        }

        private static IServiceCollection AddDataLoader(this IServiceCollection services)
        {
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();

            return services;
        }

        private static IServiceCollection AddInputType(this IServiceCollection services)
        {
            services.AddSingleton<BillCreateInput>();
            services.AddSingleton<BillIdInput>();
            services.AddSingleton<BookingCreateInput>();
            services.AddSingleton<BookAndCheckInCreateInput>();
            services.AddSingleton<BookingIdInput>();
            services.AddSingleton<EmployeeCreateInput>();
            services.AddSingleton<EmployeeUpdateInput>();
            services.AddSingleton<EmployeeIdInput>();
            services.AddSingleton<FloorCreateInput>();
            services.AddSingleton<FloorUpdateInput>();
            services.AddSingleton<FloorIdInput>();
            services.AddSingleton<HouseKeepingCreateInput>();
            services.AddSingleton<HouseKeepingIdInput>();
            services.AddSingleton<PatronCreateInput>();
            services.AddSingleton<PatronUpdateInput>();
            services.AddSingleton<PatronIdInput>();
            services.AddSingleton<PatronKindCreateInput>();
            services.AddSingleton<PatronKindUpdateInput>();
            services.AddSingleton<PatronKindIdInput>();
            services.AddSingleton<PositionCreateInput>();
            services.AddSingleton<PositionUpdateInput>();
            services.AddSingleton<PositionIdInput>();
            services.AddSingleton<RateCreateInput>();
            services.AddSingleton<RateUpdateInput>();
            services.AddSingleton<ReceiptCreateInput>();
            services.AddSingleton<RoomCreateInput>();
            services.AddSingleton<RoomUpdateInput>();
            services.AddSingleton<RoomIdInput>();
            services.AddSingleton<RoomKindCreateInput>();
            services.AddSingleton<RoomKindUpdateInput>();
            services.AddSingleton<RoomKindIdInput>();
            services.AddSingleton<ServiceIdInput>();
            services.AddSingleton<ServiceCreateInput>();
            services.AddSingleton<ServiceUpdateInput>();
            services.AddSingleton<ServicesDetailHouseKeepingInput>();
            services.AddSingleton<ServicesDetailCreateInput>();
            services.AddSingleton<ServicesDetailUpdateInput>();
            services.AddSingleton<ServicesDetailIdInput>();
            services.AddSingleton<VolatilityRateCreateInput>();
            services.AddSingleton<VolatilityRateUpdateInput>();

            return services;
        }

        private static IServiceCollection AddObjectType(this IServiceCollection services)
        {
            services.AddSingleton<AuthenticationType>();
            services.AddSingleton<BillType>();
            services.AddSingleton<BookingType>();
            services.AddSingleton<EmployeeType>();
            services.AddSingleton<FloorType>();
            services.AddSingleton<HouseKeepingType>();
            services.AddSingleton<PatronKindType>();
            services.AddSingleton<PatronType>();
            services.AddSingleton<PositionType>();
            services.AddSingleton<RateType>();
            services.AddSingleton<ReceiptType>();
            services.AddSingleton<RoomKindType>();
            services.AddSingleton<RoomType>();
            services.AddSingleton<ServicesDetailType>();
            services.AddSingleton<ServiceType>();
            services.AddSingleton<VolatilityRateType>();

            return services;
        }

        private static IServiceCollection AddResolver(this IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            return services;
        }

        private static IServiceCollection AddSchema(this IServiceCollection services)
        {
            services.AddSingleton<AppQuery>();
            services.AddSingleton<AppMutation>();
            services.AddSingleton<ISchema, AppSchema>();

            return services;
        }

        private static IServiceCollection AddAuthorization(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();
            services.TryAddSingleton<AuthorizationSettings>();

            return services;
        }

        public static ServiceProvider GetInitializedServiceProvider()
        {
            return new ServiceCollection()
                .AddGraphQL()
                .BuildServiceProvider();
        }
    }
}
