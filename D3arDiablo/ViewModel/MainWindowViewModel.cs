using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using D3arDiablo.Build;
using D3arDiablo.Storage;

namespace D3arDiablo.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    public MainWindowViewModel()
    {
      BuildTabs = new ObservableCollection<BuildTabViewModel>();
      var s = new StorageManager();
      BuildRegistry registry = new BuildRegistry();
      foreach (IBuild b in registry.GetBuilds(CurrentClass))
      {
        BuildTabs.Add(new BuildTabViewModel(b));
      }
    }

    public ObservableCollection<BuildTabViewModel> BuildTabs
    {
      get; set; 
    }

    public CharacterClass CurrentClass
    {
      get { return CharacterClass.Monk; }
    }
  }
}
