using System;

namespace Auto.Website.Models
{

    public class OwnerDto
    {
       
        public OwnerDto(string firstName, string lastName, string middleName, string age, string town, string address, string vehicleNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = Convert.ToInt32(age);
            Town = town;
            Address = address;
            VehicleNumber = vehicleNumber;
        }

        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }

        public string? VehicleNumber { get; set; }

        [Newtonsoft.Json.JsonIgnore] public string GetDriverLicence => $"{Address}";
    }}