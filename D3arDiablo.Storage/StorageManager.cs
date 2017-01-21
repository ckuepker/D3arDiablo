using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using D3arDiablo.Build;
using D3arDiablo.Build.XML;

namespace D3arDiablo.Storage
{
  public class StorageManager : IStorageManager
  {
    private readonly string _storagePath = D3arDiablo.Settings.Storage.StorageDefaultLocation;

    public IDictionary<CharacterClass, IEnumerable<IBuild>> LoadFromDefaultLocation()
    {
      Console.WriteLine("Loading builds from location: '" + _storagePath + "'");
      if (!File.Exists(_storagePath))
      {
        Console.WriteLine("Storage does not exist. Creating default empty storage...");
        CreateDefaultStorage();
      }
      IBuildSerializer serializer = new BuildSerializer();
      return serializer.Deserialize(_storagePath);
    }

    public void StoreAtDefaultLocation(IDictionary<CharacterClass, IEnumerable<IBuild>> builds)
    {
      if (File.Exists(_storagePath))
      {
        Console.WriteLine("Deleting previous storage version at " + _storagePath);
        File.Delete(_storagePath);
      }
      IBuildSerializer serializer = new BuildSerializer();
      serializer.Serialize(builds, _storagePath);
      Console.WriteLine("New storage saved to "+_storagePath);
    }

    private void CreateDefaultStorage()
    {
      var directoryInfo = new FileInfo(_storagePath).Directory;
      if (directoryInfo != null)
      {
        Directory.CreateDirectory(directoryInfo.FullName);
      }
      using (var resource = Assembly.GetAssembly(typeof(StorageManager)).GetManifestResourceStream("Resources/DefaultStorageTemplate.xml"))
      {
        if (resource != null)
        {
          using (var file = new FileStream(_storagePath, FileMode.Create, FileAccess.Write))
          {
            resource.CopyTo(file);
            file.Close();
          }
        }
        else
        {
          using (var template = new FileStream("Resources/DefaultStorageTemplate.xml", FileMode.Open, FileAccess.Read))
          {
            using (var target = new FileStream(_storagePath, FileMode.Create, FileAccess.Write))
            {
              template.CopyTo(target);
              target.Close();
            }
            template.Close();
          }
        }
      }

    }
  }
}
