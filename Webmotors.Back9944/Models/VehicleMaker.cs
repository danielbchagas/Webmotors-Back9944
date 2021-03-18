namespace Webmotors.Back9944.Models {
    public class VehicleMaker : Entity {
        public string Name {get;set;}

        public virtual VehicleModel Model {get;set;}
    }
}