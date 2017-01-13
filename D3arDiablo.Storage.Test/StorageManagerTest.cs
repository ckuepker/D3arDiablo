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
    private string _workingDirectory;

    [SetUp]
    public void Setup()
    {
      _workingDirectory = Environment.CurrentDirectory;
      if (File.Exists(_testLocation))
      {
        File.Delete(_testLocation);
      }
      StorageSettings.StorageDefaultLocation = TestContext.CurrentContext.TestDirectory +
                                               "/Resources/BuildExample.xml";
    }

    [TearDown]
    public void TearDown()
    {
      File.Delete(_testLocation);
      Environment.CurrentDirectory = _workingDirectory;
    }

    [Test]
    public void TestLoadFromDefaultLocation()
    {
      _manager = new StorageManager();
      IDictionary<CharacterClass, IEnumerable<IBuild>> result = _manager.LoadFromDefaultLocation();
      Assert.AreEqual(result[CharacterClass.Crusader].First().Name, "LoN");
    }

    [Test]
    public void TestLoadFromDefaultLocationWithCreateDefault()
    {
      Assert.IsFalse(File.Exists(_testLocation), "Test file should be deleted initially");
      StorageSettings.StorageDefaultLocation = _testLocation;

      Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
      _manager = new StorageManager();
      IDictionary<CharacterClass, IEnumerable<IBuild>> result = _manager.LoadFromDefaultLocation();

      Assert.IsTrue(File.Exists(_testLocation), "Test file should have been created");
      Assert.AreEqual("Lashing Tail Kick Sunwoko", result[CharacterClass.Monk].First().Name);
    }
  }
}
