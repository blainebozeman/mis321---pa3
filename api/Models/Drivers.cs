using Microsoft.AspNetCore.Cors;
namespace api.Models
{
    public class Drivers
    {
        public int Id {get; set;} 
        public string Name {get; set;} = "";
        public int Rating {get; set;}
        public DateTime DateHired {get; set;}
        public bool Deleted {get; set;}
        
        public override string ToString()
        {
            return Id + " " + Name + " " + Rating;
        }


    }
}