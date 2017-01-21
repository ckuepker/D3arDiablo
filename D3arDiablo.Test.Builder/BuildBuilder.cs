using D3arDiablo.Build;

namespace D3arDiablo.Test.Builder
{
    public class BuildBuilder
    {
      public static IBuild BuildDefaultBuild()
      {
        IBuild build =  new Build.Build();
        build.Name = "DefaultBuild";
        build.AddItem(Slot.Head, new Item("Helm of Default Instantiation", "www.inc47.de", false, false));
        return build;
      }
    }
}
