
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using D3arDiablo.BattleNet;
using D3arDiablo.Build;

namespace D3arDiablo.Storage.Cache
{
  public class ImageCache : IImageCache
  {
    private const string Extension = ".png";

    private readonly DirectoryInfo _cacheDirectory;

    public ImageCache()
    {
      _cacheDirectory = new DirectoryInfo(D3arDiablo.Settings.Storage.ImageCacheLocation);
      if (!_cacheDirectory.Exists)
      {
        _cacheDirectory.Create();
      }
    }

    public void LoadItemImage(IItem item, ItemImageSize size, Action<string> callback)
    {
      if (string.IsNullOrEmpty(item.Name))
      {
        callback(string.Empty);
        return;
      }
      string target = _cacheDirectory.FullName + GetFileName(item.Name, size);
      if (File.Exists(target))
      {
        callback(target);
        return;
      }
      Task.Run(() =>
      {
        IItemImageDownloader dl = new ItemImageDownloader();
        dl.DownloadImage(item, target);
        callback(target);
      });
    }

    private string GetFileName(String name, ItemImageSize size)
    {
      Encoding iso = Encoding.GetEncoding("ISO-8859-1");
      Encoding utf8 = Encoding.UTF8;
      byte[] utfBytes = utf8.GetBytes(name);
      byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
      string filename = iso.GetString(isoBytes);
      filename = filename.ToLower();
      filename = filename.Replace(" ", "_");
      filename += "_" + size.ToString().ToLower();
      filename += Extension;
      return filename;
    }
  }
}
