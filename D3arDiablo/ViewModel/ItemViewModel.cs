using System.ComponentModel;
using System.Windows.Media;
using D3arDiablo.Build;
using D3arDiablo.Storage.Cache;

namespace D3arDiablo.ViewModel
{
  public class ItemViewModel : ViewModelBase
  {
    private IItem _item;
    private string _imagePath;


    public ItemViewModel(IItem item)
    {
      _item = item;
      _imagePath = "/Resources/Image/default_item.png";
      IImageCache cache = new ImageCache();
      cache.LoadItemImage(item, ItemImageSize.Large, (path) =>
      {
        if (!string.IsNullOrEmpty(path))
        {
          Image = path;
        }
      });
    }

    public string Image
    {
      get { return _imagePath; }
      set
      {
        if (value != null && value != _imagePath)
        {
          _imagePath = value;
        }
        OnPropertyChanged("Image");
      }
    }

    public string Name
    {
      get { return _item.Name; }
    }

    public Slot Slot
    {
      get { return _item.Slot; }
    }
  }
}
