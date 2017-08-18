using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;

    public Stylist(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }

    public override bool Equals(System.Object otherObject)
    {
      if (!(otherObject is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherObject;

        bool namesEquality = this.GetName().Equals(newStylist.GetName());
        bool idEquality = this.GetId().Equals(newStylist.GetId());
        return namesEquality && idEquality;
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }


    public static List<Stylist> GetAll()
    {
      List<Stylist> stylistList = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        stylistList.Add(newStylist);
      }
      conn.Close();
      return stylistList;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@stylistName);";

      MySqlParameter stylistName = new MySqlParameter();
      stylistName.ParameterName = "@stylistName";
      stylistName.Value = _name;
      cmd.Parameters.Add(stylistName);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
