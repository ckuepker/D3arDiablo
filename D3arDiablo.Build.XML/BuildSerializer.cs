using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace D3arDiablo.Build.XML
{
  /// <summary>
  /// Default implementation of IBuildSerializer
  /// </summary>
  public class BuildSerializer : IBuildSerializer
  {
    public IDictionary<CharacterClass,IEnumerable<IBuild>> Deserialize(string filePath)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(ClassesContainer));

      FileStream fs = new FileStream(filePath, FileMode.Open);
      XmlReader r = XmlReader.Create(fs);

      ClassesContainer cc;

      cc = (ClassesContainer) serializer.Deserialize(r);

      fs.Close();
      fs.Dispose();

      Dictionary<CharacterClass,IEnumerable<IBuild>> builds = new Dictionary<CharacterClass, IEnumerable<IBuild>>();

      builds.Add(CharacterClass.Barbarian, GetBuildsFromBuildContainer(cc.Barbarian));
      builds.Add(CharacterClass.Crusader, GetBuildsFromBuildContainer(cc.Crusader));
      builds.Add(CharacterClass.DemonHunter, GetBuildsFromBuildContainer(cc.DemonHunter));
      builds.Add(CharacterClass.Monk, GetBuildsFromBuildContainer(cc.Monk));
      builds.Add(CharacterClass.WitchDoctor, GetBuildsFromBuildContainer(cc.WitchDoctor));
      builds.Add(CharacterClass.Wizard, GetBuildsFromBuildContainer(cc.Wizard));

      return builds;
    }

    public void Serialize(string filePath)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      // NOOP
    }

    private IEnumerable<IBuild> GetBuildsFromBuildContainer(BuildContainer buildContainer)
    {
      List<D3arDiablo.Build.Build> builds = new List<D3arDiablo.Build.Build>();
      if (buildContainer == null || buildContainer.Build == null)
      {
        return builds;
      }
      foreach (Build b in buildContainer.Build)
      {
        Dictionary<D3arDiablo.Build.Slot,IItem> items = new Dictionary<D3arDiablo.Build.Slot, IItem>();

        items[D3arDiablo.Build.Slot.CubeArmor] = GetItemFromSlot(b.CubeArmor);
        items[D3arDiablo.Build.Slot.CubeJewelry] = GetItemFromSlot(b.CubeJewelry);
        items[D3arDiablo.Build.Slot.CubeWeapon] = GetItemFromSlot(b.CubeWeapon);
        items[D3arDiablo.Build.Slot.Feet] = GetItemFromSlot(b.Feet);
        items[D3arDiablo.Build.Slot.Hands] = GetItemFromSlot(b.Hands);
        items[D3arDiablo.Build.Slot.Head] = GetItemFromSlot(b.Head);
        items[D3arDiablo.Build.Slot.MainFinger] = GetItemFromSlot(b.MainFinger);
        items[D3arDiablo.Build.Slot.MainHand] = GetItemFromSlot(b.MainHand);
        items[D3arDiablo.Build.Slot.Neck] = GetItemFromSlot(b.Neck);
        items[D3arDiablo.Build.Slot.OffFinger] = GetItemFromSlot(b.OffFinger);
        items[D3arDiablo.Build.Slot.OffHand] = GetItemFromSlot(b.OffHand);
        items[D3arDiablo.Build.Slot.Shoulder] = GetItemFromSlot(b.Shoulder);
        items[D3arDiablo.Build.Slot.Torso] = GetItemFromSlot(b.Torso);
        items[D3arDiablo.Build.Slot.Waist] = GetItemFromSlot(b.Waist);
        items[D3arDiablo.Build.Slot.Wrist] = GetItemFromSlot(b.Wrist);
        items[D3arDiablo.Build.Slot.Legs] = GetItemFromSlot(b.Legs);

        D3arDiablo.Build.Build build = new D3arDiablo.Build.Build(b.Name, items);
        builds.Add(build);
      }
      return builds;
    }

    private IItem GetItemFromSlot(Slot slot)
    {
      Item i = slot.Item;
      if (i != null)
      {
        return new D3arDiablo.Build.Item(i.Name, i.URL, i.Ancient, i.Found);
      }
      return new UnspecifiedItem();
    }
  }
}
