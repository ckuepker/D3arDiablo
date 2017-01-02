using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3arDiablo.ViewModel
{
  public class BuildTabViewModel : ViewModelBase
  {
    public BuildTabViewModel(string title)
    {
      Title = title;
    }

    public string Title { get; set; }

    public ICollection<BuildViewModel> Build { get; set; }
  }
}
