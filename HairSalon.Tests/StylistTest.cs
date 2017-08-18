using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=hair_salon_test;";
    }

    [TestMethod]
    public void GetAll_GetAllStylistsAtFirst_0()
    {
      int expected = 0;
      int actual = Stylist.GetAll().Count;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Save_SavesStylistToDataBase_StylistList()
    {
      Stylist newStylist = new Stylist("Sally Jones");
      newStylist.Save();

      List<Stylist> expected = new List<Stylist> {newStylist};
      List<Stylist> actual = Stylist.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Find_FindsStylistByIdInDatabase_Stylist()
    {
      Stylist expected = new Stylist("Harry");
      expected.Save();

      Stylist actual = Stylist.Find(expected.GetId());

      Assert.AreEqual(expected, actual);
    }

    // [TestMethod]
    // public void Update_UpdatesStylistNameInDatabase_Stylist()
    // {
    // }

    // [TestMethod]
    // public void Delete_DeleteStylistByIdInDatabase_StylistList()
    // {
    // }

    // [TestMethod]
    // public void Delete_DeleteAllResturantsFromSpecificStylist_RestaurantList()
    // {
    // }

    [TestMethod]
    public void GetAllClients_ReturnsAllClientsOfStylist_ClientList()
    {
      Stylist stylistOne = new Stylist("Jon");
      Stylist stylistTwo = new Stylist("Snow");
      stylistOne.Save();
      stylistTwo.Save();

      Client clientOne = new Client("A", stylistOne.GetId());
      Client clientTwo = new Client("B", stylistOne.GetId());
      Client clientThree = new Client("C", stylistTwo.GetId());
      clientOne.Save();
      clientTwo.Save();
      clientThree.Save();

      List<Client> expected = new List<Client> {clientOne, clientTwo};
      List<Client> actual = stylistOne.GetAllClients();

      CollectionAssert.AreEqual(expected, actual);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
