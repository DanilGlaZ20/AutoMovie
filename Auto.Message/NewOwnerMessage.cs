using System;

namespace Auto.Message
{

    public class NewOwnerMessage
    {
        public NewOwnerMessage(string firstName,  string lastName, 
            int age, string town, string address, string? regCodeVehicle = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Town = town;
            Address = address;
            RegCodeVehicle = regCodeVehicle;
            CreatedAt = DateTimeOffset.Now;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public int Age { get; set; }

        public string Town { get; set; }
    
        public string Address { get; set; }

        public string? RegCodeVehicle { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}