using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3arDiablo.Build
{
  public class Item : IItem
  {
    private string _name;
    private string _url;
    private bool _isAncient;
    private bool _found;

    public Item(string name, string url, bool isAncient, bool found)
    {
      _name = name;
      _url = url;
      _isAncient = isAncient;
      _found = found;
    }

    public string Name { get { return _name; } }
    public string Url { get { return _url; } }
  }
}
