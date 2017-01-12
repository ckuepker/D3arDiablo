using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3arDiablo.Build;

namespace D3arDiablo.ViewModel
{
  public class BuildTabViewModel : ViewModelBase
  {
    public BuildTabViewModel(IBuild build)
    {
      Title = build.Name;
      Build = new BuildViewModel(build);
    }

    public string Title { get; set; }

    public BuildViewModel Build { get; set; }
  }
}
