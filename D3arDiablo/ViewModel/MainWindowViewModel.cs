using System.Collections.ObjectModel;

namespace D3arDiablo.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    public MainWindowViewModel()
    {
      BuildTabs = new ObservableCollection<BuildTabViewModel>
      {
        new BuildTabViewModel("Default Build")
      };
    }

    public ObservableCollection<BuildTabViewModel> BuildTabs
    {
      get; set; 
    }
  }
}
