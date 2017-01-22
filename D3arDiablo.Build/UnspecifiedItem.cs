using System;
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
      return obj is UnspecifiedItem;
    }

    public string Name { get { return "Unspecified Item"; } }
    public string Url { get { return ""; } }
    public bool Ancient { get { return false; } }
    public bool Found { get { return false; } }
    public Slot Slot { get; private set; }
  }
}
