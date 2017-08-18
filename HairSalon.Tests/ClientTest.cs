using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=hair_salon_test;";
    }

    [TestMethod]
    public void GetAll_GetAllClientsAtFirst_0()
    {
      int expected = 0;
      int actual = Client.GetAll().Count;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Save_SavesClientToDatabase_ClientList()
    {

    }

    [TestMethod]
    public void Update_UpdatesClientNameInDatabase_Client()
    {

    }

    [TestMethod]
    public void Delete_DeletesClientInDatabase_ClientList()
    {

    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
