using System;
using System.IO;
using System.Threading;
using D3arDiablo.Build;
using D3arDiablo.Storage.Cache;
using log4net;
using NUnit.Framework;

namespace D3arDiablo.Storage.Test.Cache
{
  public class ImageCacheTest
  {
    private DirectoryInfo _cacheDirectory;
    private readonly ILog _log = LogManager.GetLogger(typeof(ImageCacheTest));

    [SetUp]
    public void Setup()
    {
      Settings.Storage.ImageCacheLocation = TestContext.CurrentContext.TestDirectory + "/ImageCache/";
      _cacheDirectory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory + "/ImageCache/");
      if (_cacheDirectory.Exists)
      {
        foreach (FileInfo image in _cacheDirectory.EnumerateFiles())
        {
          image.Delete();
        }
      }
    }

    [Test]
    public void TestConstructorCreatesDirectory()
    {
      if (_cacheDirectory.Exists)
      {
        _cacheDirectory.Delete();
      }
      IImageCache cache = new ImageCache();
      DirectoryAssert.Exists(_cacheDirectory);
    }

    [Test, MaxTime(30000)]
    public void TestLoadItemImage()
    {
      IItem item = new Item("HELM OF THE CRANIAL CRUSTACEAN", "http://us.battle.net/d3/en/item/helm-of-the-cranial-crustacean", false, false);
      IImageCache cache = new ImageCache();
      var finished = false;
      cache.LoadItemImage(item, ItemImageSize.Large, (path) =>
      {
        _log.Info("Downloaded image to '"+path+"'");
        FileAssert.Exists(path);
        Assert.IsTrue(path.EndsWith(".png"));
        finished = true;
      });
      while (!finished)
      {
        Thread.Sleep(1000);
      }
    }

    [Test, MaxTime(30000)]
    public void TestLoadItemImageAlreadyExisting()
    {
      IItem item = new Item("HELM OF THE CRANIAL CRUSTACEAN", "http://us.battle.net/d3/en/item/helm-of-the-cranial-crustacean", false, false);
      IImageCache cache = new ImageCache();
      var finished = false;
      cache.LoadItemImage(item, ItemImageSize.Large, (path1) =>
      {
        IImageCache cache2 = new ImageCache();
        cache2.LoadItemImage(item, ItemImageSize.Large, (path2) =>
        {
          Assert.AreEqual(path1, path2);
          finished = true;
        });
      });
      while (!finished)
      {
        Thread.Sleep(1000);
      }
    }

    [Test, MaxTime(30000)]
    public void TestLoadItemImageWithoutName()
    {
      IItem item = new Item(string.Empty, "http://us.battle.net/d3/en/item/helm-of-the-cranial-crustacean", false, false);
      bool finished = false;
      ImageCache cache = new ImageCache();
      cache.LoadItemImage(item, ItemImageSize.Large, (path) =>
      {
        Assert.IsTrue(string.IsNullOrEmpty(path));
        finished = true;
      });
      while (!finished)
      {
        Thread.Sleep(1000);
      }
    }
  }
}
