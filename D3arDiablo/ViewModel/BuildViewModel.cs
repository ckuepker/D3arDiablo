using D3arDiablo.Build;

namespace D3arDiablo.ViewModel
{
  public class BuildViewModel : ViewModelBase
  {
    private IBuild _build;

    public BuildViewModel(IBuild build)
    {
      _build = build;
    }
  }
}
