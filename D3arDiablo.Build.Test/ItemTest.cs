
using System;
using NUnit.Framework;

namespace D3arDiablo.Build.Test
{
  public class ItemTest
  {
    [Test]
    public void TestEquals()
    {
      IItem i1 = new Item(Slot.CubeArmor, "a", "b", false, false);
      IItem i2 = new Item(Slot.CubeArmor, "a", "b", false, false);
      Assert.IsTrue(i1.Equals(i2));
    }

    [Test]
    public void TestEqualsInequalityOnSlot()
    {
      IItem i1 = new Item(Slot.CubeArmor, "a", "b", false, false);
      IItem i2 = new Item(Slot.Legs, "a", "b", false, false);
      Assert.IsFalse(i1.Equals(i2));
    }

    [Test]
    public void TestEqualsInequalityOnName()
    {
      IItem i1 = new Item(Slot.CubeArmor, "a", "b", false, false);
      IItem i2 = new Item(Slot.CubeArmor, "x", "b", false, false);
      Assert.IsFalse(i1.Equals(i2));
    }

    [Test]
    public void TestEqualsInequalityOnUrl()
    {
      IItem i1 = new Item(Slot.CubeArmor, "a", "b", false, false);
      IItem i2 = new Item(Slot.CubeArmor, "a", "x", false, false);
      Assert.IsFalse(i1.Equals(i2));
    }

    [Test]
    public void TestEqualsInequalityOnAncient()
    {
      IItem i1 = new Item(Slot.CubeArmor, "a", "b", false, false);
      IItem i2 = new Item(Slot.CubeArmor, "a", "b", true, false);
      Assert.IsFalse(i1.Equals(i2));
    }

    [Test]
    public void TestEqualsInequalityOnFound()
    {
      IItem i1 = new Item(Slot.CubeArmor, "a", "b", false, false);
      IItem i2 = new Item(Slot.CubeArmor, "a", "b", false, true);
      Assert.IsFalse(i1.Equals(i2));
    }

    [Test]
    public void TestEqualsInequalityOnNull()
    {
      IItem i1 = new Item(Slot.CubeArmor, "a", "b", false, false);
      Assert.IsFalse(i1.Equals(null));
    }
  }
}
