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
      Client newClient = new Client("Shaggy", 1);
      newClient.Save();

      List<Client> expected = new List<Client> {newClient};
      List<Client> actual = Client.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Update_UpdatesClientNameInDatabase_String()
    {
      Client testClient = new Client("Mullet Man", 1);
      testClient.Save();

      string expected = "Cleaned up";
      testClient.Update(expected);
      string actual = testClient.GetName();

      Assert.AreEqual(expected, actual);

    }

    [TestMethod]
    public void Delete_DeletesClientInDatabase_ClientList()
    {
      Client clientOne = new Client("Dreads", 1);
      Client clientTwo = new Client("Afro", 1);
      clientOne.Save();
      clientTwo.Save();
      clientOne.Delete();

      List<Client> expected = new List<Client> {clientTwo};
      List<Client> actual = Client.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Find_FindsClientByIdInDatabase_Client()
    {
      Client expected = new Client("Weave", 1);
      expected.Save();

      Client actual = Client.Find(expected.GetId());

      Assert.AreEqual(expected, actual);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
