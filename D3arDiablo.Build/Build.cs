using System;
using System.Collections.Generic;

namespace D3arDiablo.Build
{
    public class Build : IBuild
    {
      private Dictionary<Slot, IItem> _items;

      public Build()
      {
        _items = new Dictionary<Slot, IItem>();
        foreach (Slot s in Enum.GetValues(typeof(Slot)))
        {
          _items.Add(s, new UnspecifiedItem());
        }
      }

      public IItem GetItem(Slot slot)
      {
        return _items[slot];
      }
    }
}
