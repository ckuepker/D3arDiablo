using System.IO;
using D3arDiablo.Build;
using NUnit.Framework;

namespace D3arDiablo.BattleNet.Test
{
  public class ItemImageDownloaderTest
  {
    private readonly string _testImageLocation = TestContext.CurrentContext.TestDirectory + "/downloaded.png";
    private IItemImageDownloader _sut;
    [SetUp]
    public void Setup()
    {
      DeleteTestFile();
      _sut = new ItemImageDownloader();
    }

    [TearDown]
    public void TearDown()
    {
      DeleteTestFile();
    }

    private void DeleteTestFile()
    {
      if (File.Exists(_testImageLocation))
      {
        File.Delete(_testImageLocation);
      }
    }

    [Test]
    public void TestImageDownload()
    {
      Assert.IsFalse(File.Exists(_testImageLocation), "Target image should not exist before test");
      IItem item = new Item(Slot.Head, "Tal Rasha's Guise of Wisdom","http://us.battle.net/d3/en/item/tal-rashas-guise-of-wisdom", false, false);
      _sut.DownloadImage(item, _testImageLocation);

      Assert.IsTrue(File.Exists(_testImageLocation));
    }

    [Test]
    public void TestInvalidImageDownload()
    {
      Assert.IsFalse(File.Exists(_testImageLocation), "Target image should not exist before test");
      IItem item = new Item(Slot.CubeArmor, "Invented Item", "http://us.battle.net/d3/en/item/iamnotitem", false, false);
      _sut.DownloadImage(item, _testImageLocation);

      Assert.IsFalse(File.Exists(_testImageLocation));
    }
  }
}
