using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=;password=root;port=3306;database=hair_salon_test;";
    }
