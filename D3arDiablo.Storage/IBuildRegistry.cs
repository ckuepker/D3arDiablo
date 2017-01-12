using System.Collections.Generic;
using D3arDiablo.Build;

namespace D3arDiablo.Storage
{
  public interface IBuildRegistry
  {
    /// <summary>
    /// Returns all builds available for the given class
    /// </summary>
    /// <param name="class"></param>
    /// <returns></returns>
    IEnumerable<IBuild> GetBuilds(CharacterClass @class);
  }
}
