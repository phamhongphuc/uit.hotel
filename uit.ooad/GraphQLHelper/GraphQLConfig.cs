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
using uit.ooad.ObjectTypes;
using uit.ooad.Queries;
using uit.ooad.Schemas;

namespace uit.ooad.GraphQLHelper
{
    public class GraphQLConfig
    {
        public static void DataLoader(IServiceCollection services)
        {
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();
        }

        public static void Input(IServiceCollection services)
        {
            services.AddSingleton<BillCreateInput>();
            services.AddSingleton<BillIdInput>();
            services.AddSingleton<BookingCreateInput>();
            services.AddSingleton<BookingIdInput>();
            services.AddSingleton<EmployeeCreateInput>();
            services.AddSingleton<EmployeeIdInput>();
            services.AddSingleton<FloorCreateInput>();
            services.AddSingleton<FloorUpdateInput>();
            services.AddSingleton<FloorIdInput>();
            services.AddSingleton<HouseKeepingCreateInput>();
            services.AddSingleton<HouseKeepingIdInput>();
            services.AddSingleton<PatronCreateInput>();
            services.AddSingleton<PatronIdInput>();
            services.AddSingleton<PatronKindCreateInput>();
            services.AddSingleton<PatronKindIdInput>();
            services.AddSingleton<PositionCreateInput>();
            services.AddSingleton<PositionIdInput>();
            services.AddSingleton<RateCreateInput>();
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
            services.AddSingleton<ServicesDetailCreateInput>();
            services.AddSingleton<ServicesDetailIdInput>();
            services.AddSingleton<VolatilityRateCreateInput>();
        }

        public static ServiceProvider GetServiceProvider(Action<ServiceCollection> function)
        {
            var services = new ServiceCollection();
            function(services);
            return services.BuildServiceProvider();
        }

        public static void Type(IServiceCollection services)
        {
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
        }

        public static void Config(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
        }

        public static void App(IServiceCollection services)
        {
            services.AddSingleton<AppQuery>();
            services.AddSingleton<AppMutation>();
            services.AddSingleton<ISchema, AppSchema>();
        }

        public static void Auth(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();
            services.TryAddSingleton<AuthorizationSettings>();
        }
    }
}
