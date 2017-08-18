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
    public void FindAllClients_ReturnsAllClientsOfStylist_ClientList()
    {
    }

    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }
  }
}
