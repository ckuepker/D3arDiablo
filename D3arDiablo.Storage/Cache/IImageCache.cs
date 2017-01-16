using System;
using System.Threading.Tasks;
using D3arDiablo.Build;

namespace D3arDiablo.Storage.Cache
{
  public interface IImageCache
  {
    /// <summary>
    /// Loads an item asynchronously into the cache and passes the path into the callback when ready
    /// </summary>
    /// <param name="item"></param>
    /// <param name="size"></param>
    /// <param name="callback"></param>
    void LoadItemImage(IItem item, ItemImageSize size, Action<string> callback);
  }
}
