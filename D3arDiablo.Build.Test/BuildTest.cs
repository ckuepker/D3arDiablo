
using System;
using NUnit.Framework;

namespace D3arDiablo.Build.Test
{
    public class BuildTest
    {

      [Test]
      public void BuildOnlyContainsUnspecifiedItemsOnDefaultInstantiation()
      {
        IBuild b = new Build();
        IItem unspecified = new UnspecifiedItem();
        foreach (Slot s in Enum.GetValues(typeof(Slot)))
        {
          Assert.AreEqual(unspecified, b.GetItem(s));
        }
      }
    }
}
