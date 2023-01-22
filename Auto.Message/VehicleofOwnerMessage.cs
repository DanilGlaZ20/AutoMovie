using System;
using System.Net.Sockets;

namespace Auto.Message
{
    public class NewVehicleOfOwnerMessage{

    public NewVehicleOfOwnerMessage( string address, string? newVehicle, string? oldVehicle)
    {
        Address=address;
        NewVehicle = newVehicle;
        OldVehicle = oldVehicle;
        CreatedAt = DateTimeOffset.Now;
    }
    
    public string Address { get; set; }
    public string? NewVehicle { get; set; }
    public string? OldVehicle { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
}