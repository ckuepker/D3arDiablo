using System;
using System.Collections;
using System.Collections.Generic;
using D3arDiablo.Build;

namespace D3arDiablo.Storage
{
  public class BuildRegistry : IBuildRegistry
  {
    private IDictionary<CharacterClass, IEnumerable<IBuild>> _builds;

    public BuildRegistry()
    {
      IStorageManager storage = new StorageManager();
      _builds = storage.LoadFromDefaultLocation();
    }

    public IEnumerable<IBuild> GetBuilds(CharacterClass @class)
    {
      return new List<IBuild>(_builds[@class]);
    }
  }
}
