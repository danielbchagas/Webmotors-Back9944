namespace Webmotors.Back9944.Business.Models
{
    public class Vehicle : Entity
    {
        public string Make {get;set;}
        public string Model {get;set;}
        public string Version {get;set;}
        public string Image {get;set;}
        public double Km {get;set;}
        public string Price {get;set;}
        public int YearModel {get;set;}
        public int YearFab {get;set;}
        public string Color {get;set;}
    }
}