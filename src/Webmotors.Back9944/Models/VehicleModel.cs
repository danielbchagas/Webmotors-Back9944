namespace Webmotors.Back9944.Models {
    public class VehicleModel : Entity
    {
        public string Name {get;set;}
        public virtual VehicleVersion Version {get;set;}
    }
}