using Microsoft.AspNetCore.Cors;
namespace api.Models.Interfaces
{
    public interface IGetDriver
    {
         Drivers GetDriver(int Id);
    }
}