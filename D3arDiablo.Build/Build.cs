using System;
using System.Collections.Generic;

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

      public void AddItem(Slot slot, IItem item)
      {
        _items[slot] = item;
      }

      public override bool Equals(object obj)
      {
        if (!(obj is IBuild))
        {
          return false;
        }
        IBuild otherBuild = (IBuild) obj;
        if (otherBuild.Name != Name)
        {
          return false;
        }
        foreach (Slot s in Enum.GetValues(typeof(Slot)))
        {
          IItem myItem = _items[s];
          IItem theirItem = otherBuild.GetItem(s);
          if (!myItem.Equals(theirItem))
          {
            return false;
          }
        }
        return true;
      }
    }
}
