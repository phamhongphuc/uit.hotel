using System;
using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Mutation
{
    public class PatronMutation : RootQueryGraphType
    {
        public PatronMutation()
        {
            Field<PatronType>(
                "createPatron",
                "Tạo và trả về một khách hàng mới",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "identification" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<StringGraphType> { Name = "email" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "gender" },
                    new QueryArgument<NonNullGraphType<DateTimeOffsetGraphType>> { Name = "birthdate" },
                    new QueryArgument<NonNullGraphType<DateTimeOffsetGraphType>> { Name = "phoneNumber" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nationality" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "domicile" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "residence" },
                    new QueryArgument<StringGraphType> { Name = "company" },
                    new QueryArgument<StringGraphType> { Name = "note" }
                ),
                context => PatronBusiness.Add(new Patron
                {
                    Identification = context.GetArgument<string>("id"),
                    Name = context.GetArgument<string>("name"),
                    Email = context.GetArgument<string>("email"),
                    Gender = context.GetArgument<bool>("gender"),
                    Birthdate = context.GetArgument<DateTimeOffset>("birthdate"),
                    PhoneNumber = context.GetArgument<DateTimeOffset>("phoneNumber"),
                    Nationality = context.GetArgument<string>("nationality"),
                    Domicile = context.GetArgument<string>("domicile"),
                    Residence = context.GetArgument<string>("residence"),
                    Company = context.GetArgument<string>("company"),
                    Note = context.GetArgument<string>("note")
                })
            );
        }
    }
}
