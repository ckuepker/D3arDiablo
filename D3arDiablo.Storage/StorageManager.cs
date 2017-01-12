using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using D3arDiablo.Build;
using D3arDiablo.Build.XML;

namespace D3arDiablo.Storage
{
  public class StorageManager : IStorageManager
  {
    private readonly string _storagePath = D3arDiablo.Settings.Storage.StorageDefaultLocation;

    public IDictionary<CharacterClass, IEnumerable<IBuild>> LoadFromDefaultLocation()
    {
      if (!File.Exists(_storagePath))
      {
        CreateDefaultStorage();
      }
      IBuildSerializer serializer = new BuildSerializer();
      return serializer.Deserialize(_storagePath);
    }

    private void CreateDefaultStorage()
    {
      var directoryInfo = new FileInfo(_storagePath).Directory;
      if (directoryInfo != null)
      {
        Directory.CreateDirectory(directoryInfo.FullName);
      }
      using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("Resources/BuildDefault.xml"))
      {
        if (resource != null)
        {
          using (var file = new FileStream(_storagePath, FileMode.Create, FileAccess.Write))
          {
            resource.CopyTo(file);
          }
        }
      }

    }
  }
}
