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

    /// <summary>
    /// Stores all builds in the given registry in the default XML storage file as specified in D3arDiablo.Settings.Storage. 
    /// Previous contens will be overwritten
    /// </summary>
    /// <param name="builds">Dictionary of all builds to save</param>
    void StoreAtDefaultLocation(IDictionary<CharacterClass, IEnumerable<IBuild>> builds);
  }
}
