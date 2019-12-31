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
            services.AddSingleton<BillUpdateDiscountInput>();
            services.AddSingleton<BillUpdateInput>();
            services.AddSingleton<BookAndCheckInCreateInput>();
            services.AddSingleton<BookingCreateInput>();
            services.AddSingleton<BookingIdInput>();
            services.AddSingleton<EmployeeCreateInput>();
            services.AddSingleton<EmployeeIdInput>();
            services.AddSingleton<EmployeeUpdateInput>();
            services.AddSingleton<FloorCreateInput>();
            services.AddSingleton<FloorIdInput>();
            services.AddSingleton<FloorUpdateInput>();
            services.AddSingleton<PatronCreateInput>();
            services.AddSingleton<PatronIdInput>();
            services.AddSingleton<PatronKindCreateInput>();
            services.AddSingleton<PatronKindIdInput>();
            services.AddSingleton<PatronKindUpdateInput>();
            services.AddSingleton<PatronUpdateInput>();
            services.AddSingleton<PositionCreateInput>();
            services.AddSingleton<PositionIdInput>();
            services.AddSingleton<PositionUpdateInput>();
            services.AddSingleton<PriceCreateInput>();
            services.AddSingleton<PriceUpdateInput>();
            services.AddSingleton<PriceVolatilityCreateInput>();
            services.AddSingleton<PriceVolatilityUpdateInput>();
            services.AddSingleton<ReceiptCreateInput>();
            services.AddSingleton<ReceiptIdInput>();
            services.AddSingleton<RoomCreateInput>();
            services.AddSingleton<RoomIdInput>();
            services.AddSingleton<RoomKindCreateInput>();
            services.AddSingleton<RoomKindIdInput>();
            services.AddSingleton<RoomKindUpdateInput>();
            services.AddSingleton<RoomUpdateInput>();
            services.AddSingleton<ServiceCreateInput>();
            services.AddSingleton<ServiceIdInput>();
            services.AddSingleton<ServicesDetailCreateInput>();
            services.AddSingleton<ServicesDetailIdInput>();
            services.AddSingleton<ServicesDetailUpdateInput>();
            services.AddSingleton<ServiceUpdateInput>();

            return services;
        }

        private static IServiceCollection AddObjectType(this IServiceCollection services)
        {
            services.AddSingleton<AuthenticationType>();
            services.AddSingleton<BillStatusEnumType>();
            services.AddSingleton<BillType>();
            services.AddSingleton<BookingStatusEnumType>();
            services.AddSingleton<BookingType>();
            services.AddSingleton<EmployeeType>();
            services.AddSingleton<FloorType>();
            services.AddSingleton<PatronKindType>();
            services.AddSingleton<PatronType>();
            services.AddSingleton<PositionType>();
            services.AddSingleton<PriceItemKindEnumType>();
            services.AddSingleton<PriceItemType>();
            services.AddSingleton<PriceType>();
            services.AddSingleton<PriceVolatilityItemKindEnumType>();
            services.AddSingleton<PriceVolatilityItemType>();
            services.AddSingleton<PriceVolatilityType>();
            services.AddSingleton<ReceiptKindEnumType>();
            services.AddSingleton<ReceiptStatusEnumType>();
            services.AddSingleton<ReceiptType>();
            services.AddSingleton<RoomKindType>();
            services.AddSingleton<RoomType>();
            services.AddSingleton<ServicesDetailType>();
            services.AddSingleton<ServiceType>();

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
