using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using D3arDiablo.Build;
using NUnit.Framework;
using StorageSettings = D3arDiablo.Settings.Storage;

namespace D3arDiablo.Storage.Test
{
  public class StorageManagerTest
  {
    private IStorageManager _manager;
    private readonly string _testLocation = TestContext.CurrentContext.TestDirectory + "/teststorage.xml";

    [SetUp]
    public void Setup()
    {
      StorageSettings.StorageDefaultLocation = TestContext.CurrentContext.TestDirectory +
                                               "/Resources/BuildExample.xml";
      _manager = new StorageManager();
    }
    [Test]
    public void TestLoadFromDefaultLocation()
    {
      IDictionary<CharacterClass, IEnumerable<IBuild>> result = _manager.LoadFromDefaultLocation();
      Assert.AreEqual(result[CharacterClass.Crusader].First().Name, "LoN");
    }
  }
}
