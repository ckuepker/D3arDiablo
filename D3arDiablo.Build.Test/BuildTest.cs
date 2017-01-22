
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

      [Test]
      public void TestAddItem()
      {
        IBuild b = new Build();
        IItem addedItem = new Item(Slot.Head, "Helm of Additional Items", "www.inc47.de", true, true);
        b.AddItem(Slot.Head, addedItem);

        IItem head = b.GetItem(Slot.Head);
        Assert.AreEqual(addedItem, head);
      }

      [Test]
      public void TestAddItemReplaces()
      {
        IBuild build = new Build();
        IItem initial = new Item(Slot.Head, "Helm of Initialness", "www.inc47.de", false, false);
        build.AddItem(Slot.Head, initial);
        IItem replacement = new Item(Slot.Head, "Helm of Replacement", "www.google.de", true, true);
        build.AddItem(Slot.Head, replacement);

        Assert.AreEqual(replacement, build.GetItem(Slot.Head));
      }

      [Test]
      public void TestEquals()
      {
        IBuild b1 = new Build();
        b1.Name = "A Build";
        b1.AddItem(Slot.CubeArmor, new Item(Slot.CubeArmor, "An Item","www.inc47.de",true,true));
        IBuild b2 = new Build();
        b2.Name = "A Build";
        b2.AddItem(Slot.CubeArmor, new Item(Slot.CubeArmor, "An Item", "www.inc47.de", true, true));
        Assert.IsTrue(b1.Equals(b2));
      }

      [Test]
      public void TestEqualsInequalityOnNameDifference()
      {
        IBuild b1 = new Build();
        b1.Name = "A Build";
        b1.AddItem(Slot.CubeArmor, new Item(Slot.CubeArmor, "An Item", "www.inc47.de", true, true));
        IBuild b2 = new Build();
        b2.Name = "B Build";
        b2.AddItem(Slot.CubeArmor, new Item(Slot.CubeArmor, "An Item", "www.inc47.de", true, true));
        Assert.IsFalse(b1.Equals(b2));
      }

      [Test]
      public void TestEqualsInequalityOnItemsDifference()
      {
        IBuild b1 = new Build();
        b1.Name = "A Build";
        b1.AddItem(Slot.CubeArmor, new Item(Slot.CubeArmor, "An Item", "www.inc47.de", true, true));
        IBuild b2 = new Build();
        b2.Name = "A Build";
        b2.AddItem(Slot.Head, new Item(Slot.Head, "An Item", "www.inc47.de", true, true));
        Assert.IsFalse(b1.Equals(b2));
      }

      [Test]
      public void TestEqualsInequalityOnItemPropertyDifference()
      {
        IBuild b1 = new Build();
        b1.Name = "A Build";
        b1.AddItem(Slot.CubeArmor, new Item(Slot.CubeArmor, "An Item", "www.inc47.de", true, true));
        IBuild b2 = new Build();
        b2.Name = "A Build";
        b2.AddItem(Slot.CubeArmor, new Item(Slot.CubeArmor, "No Item", "www.inc47.de/item", false, false));
        Assert.IsFalse(b1.Equals(b2));
      }

      [Test]
      public void TestEqualsInequalityOnNull()
      {
        IBuild b1 = new Build();
        b1.Name = "A Build";
        b1.AddItem(Slot.CubeArmor, new Item(Slot.CubeArmor, "An Item", "www.inc47.de", true, true));
        Assert.IsFalse(b1.Equals(null));
      }
    }
}
