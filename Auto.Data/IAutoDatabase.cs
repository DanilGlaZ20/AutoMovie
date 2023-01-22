using System.Collections.Generic;
using Auto.Data.Entities;

namespace Auto.Data {
	public interface IAutoDatabase {
		
		public int CountVehicles();
		public int CountOwners();
		
		
		public IEnumerable<Vehicle> ListVehicles();
		public IEnumerable<Owner> ListOwners();
		public IEnumerable<Manufacturer> ListManufacturers();
		public IEnumerable<Model> ListModels();
		
		

		public Vehicle FindVehicle(string registration);
		public Model FindModel(string code);
		public Manufacturer FindManufacturer(string code);
		public Owner FindOwnerByDriverLicence(string driverLicence);
		public Owner FindOwnerByTown(string town);
		
		
public void CreateVehicle(Vehicle vehicle);
		public void UpdateVehicle(Vehicle vehicle);
		public void DeleteVehicle(Vehicle vehicle);
		
		public void CreateOwner(Owner owner);
		public void UpdateOwner(Owner owner, string name);
		public void DeleteOwner(Owner owner);
		
		
	}
}
