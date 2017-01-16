using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3arDiablo.Settings
{
  public static class Storage
  {
    private static string _storagePath;
    private static string _imageCachePath;

    public static string StorageDefaultLocation
    {
      get { return _storagePath = _storagePath ?? Environment.GetEnvironmentVariable("LOCALAPPDATA")+"/D3arDiablo/builds.xml"; }
      set
      {
        if (value != null && _storagePath != value)
        {
          _storagePath = value;
        }
      }
    }

    public static string ImageCacheLocation
    {
      get { return _imageCachePath = _imageCachePath ?? Environment.GetEnvironmentVariable("LOCALAPPDATA") + "/D3arDiablo/ItemCache/"; }
      set
      {
        if (value != null && _imageCachePath != value)
        {
          _imageCachePath = value;
        }
      }
    }
  }
}
