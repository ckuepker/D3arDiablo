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
  }
}
