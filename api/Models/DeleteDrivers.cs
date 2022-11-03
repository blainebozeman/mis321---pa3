using MySql.Data.MySqlClient;
using api.Models.Interfaces;
using api.Models;

using Microsoft.AspNetCore.Cors;
namespace api.Models
{
    public class DeleteDrivers : IDeleteDriver
    {
        public void DeleteDriver(int id){
            string cs = "server=t07cxyau6qg7o5nz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=k5j9nxg826jfmhp3;database=vajiy0c387qvu0oa;port=3306;password=ui8elf3aj8wkfy2j";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = $"update drivers set deleted = 1 where id = @driver_id;";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            // cmd.Parameters.AddWithValue("@id", driver.Id);
            cmd.Parameters.AddWithValue("@driver_id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}