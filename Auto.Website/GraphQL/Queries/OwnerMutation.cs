using System;
using System.Collections.Generic;
using Auto.Data;
using Auto.Data.Entities;
using Auto.Website.GraphQL.GraphTypes;
using GraphQL;
using GraphQL.Types;

namespace Auto.Website.GraphQL.Queries
{
    

        public class OwnerMutation : ObjectGraphType
        {
            private readonly IAutoDatabase _context;

            public OwnerMutation(IAutoDatabase context)
            {
                _context = context;

                Field<OwnerGraphType>("createOwner",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "firstName"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "lastName"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "age"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "town"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "address"},
                        new QueryArgument<StringGraphType> {Name = "vehicle"}
                    ),
                    resolve: tContext =>
                    {
                        try
                        {
                            var firstName = tContext.GetArgument<string>("firstName");
                            var lastName = tContext.GetArgument<string>("lastName");
                            var age = tContext.GetArgument<string>("age");
                            var town = tContext.GetArgument<string>("town");
                            var address = tContext.GetArgument<string>("address");
                            var vehicle = tContext.GetArgument<string>("vehicle");

                            var newOwner = new Owner
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Age = Convert.ToInt32(age),
                                Town =town,
                                Address = address
                            };

                            if (!string.IsNullOrEmpty(vehicle))
                            {
                                newOwner.Vehicle = _context.FindVehicle(vehicle);
                            }

                            _context.CreateOwner(newOwner);
                            return newOwner;
                        }
                        catch (Exception e)
                        {
                            tContext.Errors.Add(new ExecutionError(e.Message));
                            throw;
                        }
                    }
                );

                Field<OwnerGraphType>("updateOwner",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "backOwner"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "firstName"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "lastName"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "age"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "town"},
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "address"},
                        new QueryArgument<StringGraphType> {Name = "vehicle"}
                    ),
                    resolve: tContext =>
                    {
                        try
                        {
                            var backOwner = tContext.GetArgument<string>("backOwner");
                            var firstName = tContext.GetArgument<string>("firstName");
                            var lastName = tContext.GetArgument<string>("lastName");
                            var age = tContext.GetArgument<string>("age");
                            var town = tContext.GetArgument<string>("town");
                            var address = tContext.GetArgument<string>("address");
                            var vehicle = tContext.GetArgument<string>("vehicle");

                            var newOwner = new Owner
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Age = Convert.ToInt32(age),
                                Town =town,
                                Address = address
                            };

                            if (vehicle != null)
                            {
                                if (vehicle == "")
                                {
                                    newOwner.Vehicle = null;
                                }
                                else
                                {
                                    newOwner.Vehicle = _context.FindVehicle(vehicle);
                                    
                                }
                            }

                            var ownerInContext = _context.FindOwnerByDriverLicence(backOwner);
                            if (ownerInContext == null)
                            {
                                throw new KeyNotFoundException("Владелец не найден");
                            }

                            _context.UpdateOwner(newOwner, backOwner);
                            return newOwner;
                        }
                        catch (Exception e)
                        {
                            tContext.Errors.Add(new ExecutionError(e.Message));
                            throw;
                        }
                    }
                );

                Field<OwnerGraphType>("deleteOwner",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "driverLicence"}
                    ),
                    resolve: tContext =>
                    {
                        var driverLicence = tContext.GetArgument<string>("driverLicence");
                        var owner = _context.FindOwnerByDriverLicence(driverLicence);
                        _context.DeleteOwner(owner);
                        return owner; }  );   }  }  }

