using System;
using System.Collections.Generic;
using System.Linq;
using Auto.Data;
using Auto.Data.Entities;
using Auto.Website.GraphQL.GraphTypes;
using GraphQL;
using GraphQL.Types;

namespace Auto.Website.GraphQL.Queries
{

    public class OwnerQuery : ObjectGraphType
    {
        private readonly IAutoDatabase _context;

        public OwnerQuery(IAutoDatabase context)
        {
            _context = context;
            Field<OwnerGraphType>("getOwner", "Запрос для получения данных",
                new QueryArguments(MakeNonNullStringArgument("driverLicence",
                    "Эл.почта владельца")),
                resolve: GetOwner);
            Field<ListGraphType<OwnerGraphType>>("Owners", "Запрос для получения всех владельцев",
                resolve: GetAllOwners);
            Field<OwnerGraphType>("getTownOwner", "Запрос для получения данных",
                new QueryArguments(MakeNonNullStringArgument("town",
                    "Эл.почта владельца")),
                resolve: GetTownOwner);

        }

        private Owner GetOwner(IResolveFieldContext<object> context)
        {
            var name = context.GetArgument<string>("driverLicence");
            try
            { return _context.FindOwnerByDriverLicence(name) ?? throw new Exception(); }
            catch (Exception e)
            { context.Errors.Add(new ExecutionError("Такой водитель не найден")); 
                throw new Exception(); 
            }
        }
        private IEnumerable<Owner> GetAllOwners(IResolveFieldContext<object> context) => _context.ListOwners();
        private Owner GetTownOwner(IResolveFieldContext<object> context)
        {
            var name = context.GetArgument<string>("town");
            try
            { return _context.FindOwnerByTown(name) ?? throw new Exception(); }
            catch (Exception e)
            { context.Errors.Add(new ExecutionError("Такой водитель не найден")); 
                throw new Exception(); 
            }
        }


        private QueryArgument MakeNonNullStringArgument(string name, string description)
        {
            return new QueryArgument<NonNullGraphType<StringGraphType>>
            {
                Name = name, Description = description
            };} }}
