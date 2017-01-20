
namespace D3arDiablo.Build
{
  public class Item : IItem
  {
    private readonly string _name;
    private readonly string _url;

    public Item(string name, string url, bool isAncient, bool found)
    {
      _name = name;
      _url = url;
      Ancient = isAncient;
      Found = found;
    }

    public string Name { get { return _name; } }
    public string Url { get { return _url; } }
    public bool Ancient { get; private set; }
    public bool Found { get; private set; }

    
    public new bool Equals(object other)
    {
      Item otherItem = other as Item;
      if (otherItem == null)
      {
        return false;
      }
      return (otherItem.Name == Name && otherItem.Url == Url && (otherItem.Found == Found) &&
              otherItem.Ancient == Ancient);
    }
  }
}
