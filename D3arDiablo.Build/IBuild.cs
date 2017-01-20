using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace D3arDiablo.Build
{
  public interface IBuild
  {
    /// <summary>
    /// Returns the Item of this build at a specific slot or UnspecifiedItem if non is set
    /// </summary>
    /// <param name="slot"></param>
    /// <returns></returns>
    IItem GetItem(Slot slot);

    /// <summary>
    /// Holds the name of the build usable as user-readable build identification, such as 'Tal Rasha Flash Fire'
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Adds an item to this build at the specified slot. If the build already has an item at the given slot, it is replaced.
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="item"></param>
    void AddItem(Slot slot, IItem item);

    bool Equals(object other);
  }
}
