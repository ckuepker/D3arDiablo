﻿using System;
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
  }
}
