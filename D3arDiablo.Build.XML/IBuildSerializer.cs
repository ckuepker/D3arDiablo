using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3arDiablo.Build.XML
{
  /// <summary>
  /// Interface for build XML file interaction, providing methods for serialization and deserialization
  /// </summary>
  public interface IBuildSerializer : IDisposable
  {
    IDictionary<CharacterClass,IEnumerable<IBuild>> Deserialize(string filePath);
    void Serialize(IDictionary<CharacterClass,IEnumerable<IBuild>> builds, string filePath);
  }
}
