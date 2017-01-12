using System;
using NUnit.Framework;

namespace D3arDiablo.Settings.Test
{
    public class StorageTest
    {
      [Test]
      public void TestDefaultStoragePath()
      {
        Assert.AreEqual(Environment.GetEnvironmentVariable("LOCALAPPDATA")+"/D3arDiablo/builds.xml", Storage.StorageDefaultLocation);
      }

      [Test]
      public void TestOverrideStoragePath()
      {
        Storage.StorageDefaultLocation = "../somepath/file.xml";
        Assert.AreEqual("../somepath/file.xml", Storage.StorageDefaultLocation);
      }
    }
}
