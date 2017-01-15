using D3arDiablo.Build;

namespace D3arDiablo.BattleNet
{
  public interface IItemImageDownloader
  {
    /// <summary>
    /// Downloads an item image from the D3 Community API and stores it at the given location
    /// </summary>
    /// <param name="item"></param>
    /// <param name="targetFilePath"></param>
    void DownloadImage(IItem item, string targetFilePath);
  }
}
