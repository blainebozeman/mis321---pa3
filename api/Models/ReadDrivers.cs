using System.Collections.Generic;
using api.Models.Interfaces;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Cors;
using api.Models;

namespace api.Models
{
    public class ReadDrivers: IGetAllDrivers, IGetDriver
    {
      
        public List<Drivers> GetAllDrivers()
        {
            string cs = "server=t07cxyau6qg7o5nz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=k5j9nxg826jfmhp3;database=vajiy0c387qvu0oa;port=3306;password=ui8elf3aj8wkfy2j";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * from drivers where deleted = 0 order by date_hired desc";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Drivers> drivers = new List<Drivers>();
            while(rdr.Read()){
                System.Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1) + " "  + rdr.GetInt32(2) + " " + rdr.GetDateTime(3) + " " + rdr.GetBoolean(4));
                Drivers newDriver = new Drivers(){Id = rdr.GetInt32(0), Name = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4)};
                drivers.Add(newDriver);
            }

            con.Close();
            return drivers;
        }

        public Drivers GetDriver(int Id)
        {
            string cs = "server=t07cxyau6qg7o5nz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=k5j9nxg826jfmhp3;database=vajiy0c387qvu0oa;port=3306;password=ui8elf3aj8wkfy2j";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * from drivers";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Drivers(){Id = rdr.GetInt32(0), Name = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4)};

//Hello! Adding this in!


        }

    }
}