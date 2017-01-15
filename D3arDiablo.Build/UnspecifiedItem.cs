﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3arDiablo.Build
{
  public class UnspecifiedItem : IItem
  {
    public override bool Equals(object obj)
    {
      return obj != null && obj.GetType() == typeof(UnspecifiedItem);
    }

    public string Name { get { return "Unspecified Item"; } }
    public string Url { get { return ""; } }
  }
}
