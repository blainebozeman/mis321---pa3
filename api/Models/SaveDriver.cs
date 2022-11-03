using MySql.Data.MySqlClient;
using api.Models.Interfaces;
using api.Models;

using Microsoft.AspNetCore.Cors;
namespace api.Models
{
    public class SaveDriver : IAddDriver
    {
        public void AddDriver(Drivers driver){
            string cs = "server=t07cxyau6qg7o5nz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=k5j9nxg826jfmhp3;database=vajiy0c387qvu0oa;port=3306;password=ui8elf3aj8wkfy2j";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = $"insert into drivers(driver_name, rating, date_hired) VALUES (@driver_name, @rating, @date_hired);";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            // cmd.Parameters.AddWithValue("@id", driver.Id);
            cmd.Parameters.AddWithValue("@driver_name", driver.Name);
            cmd.Parameters.AddWithValue("@date_hired", driver.DateHired);
            cmd.Parameters.AddWithValue("@rating", driver.Rating);
            cmd.Prepare();
            cmd.ExecuteNonQuery();


        }

        
    }
}