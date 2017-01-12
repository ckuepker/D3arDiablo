using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace D3arDiablo.Storage
{
    public interface IStorageManager
    {
      /// <summary>
      /// Tries to load all builds in the 
      /// </summary>
      /// <returns></returns>
      IDictionary<CharacterClass, IEnumerable<IBuild>> LoadFromDefaultLocation();
    }
}
