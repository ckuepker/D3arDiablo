using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace D3arDiablo.Build.Test
{
  public class SlotTest
  {
    [Test]
    public void TestCount()
    {
      Assert.AreEqual(16, Enum.GetValues(typeof(Slot)).Length, "Slot enum contains 16 values");
    }
  }
}
