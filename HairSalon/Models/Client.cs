using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylist_id;

    public Client(string name, int stylistId, int id = 0)
    {
      _id = id;
      _name = name;
      _stylist_id = stylistId;
    }

    public static void DeleteAll()
    {

    }

  }
}
