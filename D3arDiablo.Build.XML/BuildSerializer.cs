using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace D3arDiablo.Build.XML
{
  /// <summary>
  /// Default implementation of IBuildSerializer
  /// </summary>
  public class BuildSerializer : IBuildSerializer
  {
    public IDictionary<CharacterClass, IEnumerable<IBuild>> Deserialize(string filePath)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(ClassesContainer));

      FileStream fs = new FileStream(filePath, FileMode.Open);
      XmlReader r = XmlReader.Create(fs);

      ClassesContainer cc;

      cc = (ClassesContainer)serializer.Deserialize(r);

      fs.Close();
      fs.Dispose();

      Dictionary<CharacterClass, IEnumerable<IBuild>> builds = new Dictionary<CharacterClass, IEnumerable<IBuild>>();

      builds.Add(CharacterClass.Barbarian, GetBuildsFromBuildContainer(cc.Barbarian));
      builds.Add(CharacterClass.Crusader, GetBuildsFromBuildContainer(cc.Crusader));
      builds.Add(CharacterClass.DemonHunter, GetBuildsFromBuildContainer(cc.DemonHunter));
      builds.Add(CharacterClass.Monk, GetBuildsFromBuildContainer(cc.Monk));
      builds.Add(CharacterClass.WitchDoctor, GetBuildsFromBuildContainer(cc.WitchDoctor));
      builds.Add(CharacterClass.Wizard, GetBuildsFromBuildContainer(cc.Wizard));

      return builds;
    }

    public void Serialize(IDictionary<CharacterClass, IEnumerable<IBuild>> builds, string filePath)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(ClassesContainer));
      TextWriter writer = new StreamWriter(filePath);

      ClassesContainer cc = new ClassesContainer();
      cc.Barbarian = new BuildContainer();
      cc.Crusader = new BuildContainer();
      cc.DemonHunter = new BuildContainer();
      cc.Monk = new BuildContainer();
      cc.WitchDoctor = new BuildContainer();
      cc.Wizard = new BuildContainer();

      foreach (CharacterClass characterClass in Enum.GetValues(typeof(CharacterClass)))
      {
        CreateClassNodes(cc, characterClass, builds[characterClass]);
      }
      serializer.Serialize(writer, cc);
      writer.Close();
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
        Dictionary<D3arDiablo.Build.Slot, IItem> items = new Dictionary<D3arDiablo.Build.Slot, IItem>();

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

    private void CreateClassNodes(ClassesContainer container, CharacterClass characterClass, IEnumerable<IBuild> builds)
    {
      IBuild[] unserializedBuilds = builds as IBuild[] ?? builds.ToArray();
      Build[] serializedBuilds = new Build[unserializedBuilds.Length];
      for (int i = 0; i < unserializedBuilds.Length; i++)
      {
        serializedBuilds[i] = CreateBuildNodes(unserializedBuilds[i]);
      }
      switch (characterClass)
      {
        case CharacterClass.Barbarian:
          container.Barbarian.Build = serializedBuilds;
          break;
        case CharacterClass.Crusader:
          container.Crusader.Build = serializedBuilds;
          break;
        case CharacterClass.DemonHunter:
          container.DemonHunter.Build = serializedBuilds;
          break;
        case CharacterClass.Monk:
          container.Monk.Build = serializedBuilds;
          break;
        case CharacterClass.WitchDoctor:
          container.WitchDoctor.Build = serializedBuilds;
          break;
        case CharacterClass.Wizard:
          container.Wizard.Build = serializedBuilds;
          break;
        default:
          throw new ArgumentOutOfRangeException("characterClass", characterClass, null);
      }
    }

    private Build CreateBuildNodes(IBuild unserializedBuild)
    {
      Build b = new Build();

      b.Shoulder = new Slot();
      b.Hands = new Slot();
      b.MainFinger = new Slot();
      b.MainHand = new Slot();
      b.CubeWeapon = new Slot();

      b.Head = new Slot();
      b.Torso = new Slot();
      b.Waist = new Slot();
      b.Legs = new Slot();
      b.Feet = new Slot();
      b.CubeArmor = new Slot();

      b.Neck = new Slot();
      b.Wrist = new Slot();
      b.OffFinger = new Slot();
      b.OffHand = new Slot();
      b.CubeJewelry = new Slot();

      b.Name = unserializedBuild.Name;
      b.Shoulder.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Shoulder));
      b.Hands.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Hands));
      b.MainFinger.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.MainFinger));
      b.MainHand.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.MainHand));
      b.CubeWeapon.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.CubeWeapon));

      b.Head.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Head));
      b.Torso.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Torso));
      b.Waist.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Waist));
      b.Legs.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Legs));
      b.Feet.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Feet));
      b.CubeArmor.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.CubeArmor));

      b.Neck.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Neck));
      b.Wrist.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.Wrist));
      b.OffFinger.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.OffFinger));
      b.OffHand.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.OffHand));
      b.CubeJewelry.Item = CreateItemNodes(unserializedBuild.GetItem(D3arDiablo.Build.Slot.CubeJewelry));
      return b;
    }

    private Item CreateItemNodes(IItem unserializedItem)
    {
      Item i = new Item();
      i.Name = unserializedItem.Name;
      i.URL = unserializedItem.Url;
      i.Ancient = unserializedItem.Ancient;
      i.Found = unserializedItem.Found;
      return i;
    }
  }
}
