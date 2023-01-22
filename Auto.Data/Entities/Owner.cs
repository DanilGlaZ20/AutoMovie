using System.Collections;
using System.Collections.Generic;
using Auto.Data.Entities;
using Newtonsoft.Json;

namespace Auto.Data.Entities
{

    public partial class Owner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        

        [Newtonsoft.Json.JsonIgnore] public Vehicle? Vehicle { get; set; }

        [Newtonsoft.Json.JsonIgnore] public string GetDriverLicence => $"{Address}";
    }
}
