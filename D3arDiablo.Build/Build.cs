using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace D3arDiablo.Build
{
    public class Build : IBuild
    {
      private readonly Dictionary<Slot, IItem> _items = new Dictionary<Slot, IItem>();

      public Build()
      {
        foreach (Slot s in Enum.GetValues(typeof(Slot)))
        {
          if (!_items.ContainsKey(s) || _items[s] == null)
          {
            _items[s] = new UnspecifiedItem();
          }
        }
      }

      public Build(string name, Dictionary<Slot, IItem> items) : this()
      {
        Name = name;
        foreach (Slot s in items.Keys)
        {
          _items[s] = items[s];
        }
      }

      public IItem GetItem(Slot slot)
      {
        return _items[slot];
      }

      public string Name { get; set; }
    }
}
