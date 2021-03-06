﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace D3arDiablo.Build
{
  public interface IItem
  {
    string Name { get; }
    string Url { get; }
    bool Ancient { get; }
    bool Found { get; }
    Slot Slot { get; }
    bool Equals(Object other);
  }
}
