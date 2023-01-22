using Auto.Data.Entities;
using GraphQL.Types;
namespace Auto.Website.GraphQL.GraphTypes
{
    public class OwnerGraphType : ObjectGraphType<Owner>{
        public OwnerGraphType()
        {
            Name = "owner";
            Field(e => e.FirstName).Description("Имя владельца");
            Field(e => e.LastName).Description("Фамилия владельца");
            Field(e => e.Age).Description("Возраст владельца");
            Field(e => e.Town).Description("Город");
            Field(e => e.Address).Description("Email владельца");;
            Field(e => e.Vehicle, nullable: true, type: typeof(VehicleGraphType)); } }}