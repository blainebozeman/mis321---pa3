using Microsoft.AspNetCore.Cors;
namespace api.Models.Interfaces
{
    public interface IAddDriver
    {
         void AddDriver(Drivers value);
    }
}