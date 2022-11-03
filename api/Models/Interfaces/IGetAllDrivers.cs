using Microsoft.AspNetCore.Cors;
namespace api.Models.Interfaces
{
    public interface IGetAllDrivers
    {
         List<Drivers> GetAllDrivers();
    }
}