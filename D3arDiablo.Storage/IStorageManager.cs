using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3arDiablo.Build;

namespace D3arDiablo.Storage
{
  /// <summary>
  /// Interface for storage management
  /// </summary>
  public interface IStorageManager
  {
    /// <summary>
    /// Tries to load all builds from the default storage location specified in D3arDiablo.Settings.Storage
    /// </summary>
    /// <returns></returns>
    IDictionary<CharacterClass, IEnumerable<IBuild>> LoadFromDefaultLocation();
  }
}
