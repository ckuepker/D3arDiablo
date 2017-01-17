using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;

namespace D3arDiablo.Build.XML.Test
{
  public class BuildSerializerTest
  {
    private readonly string exampleFile = TestContext.CurrentContext.TestDirectory+"/Resources/BuildExample.xml";
    private IBuildSerializer _serializer;

    [SetUp]
    public void Setup()
    {
      _serializer = new BuildSerializer();
    }

    [TearDown]
    public void TearDown()
    {
      _serializer.Dispose();
      _serializer = null;
    }

    [Test]
    public void TestDeserialize()
    {
      IDictionary<CharacterClass,IEnumerable<IBuild>> builds = _serializer.Deserialize(exampleFile);
      Assert.AreEqual(6, builds.Keys.Count, "Dictionary contains builds for 6 different classes");
      Assert.AreEqual(1, builds[CharacterClass.Crusader].Count(), "Dictionary contains exactly 1 build for crusader class");
      IBuild firstBuild = builds[CharacterClass.Crusader].First();
      Assert.AreEqual("LoN", firstBuild.Name, "The crusader build is called 'LoN'");
    }

    [Test]
    public void TestSerialize()
    {
      IItem helmOfSerialization = new D3arDiablo.Build.Item("Helm of Serialization", "http://inc47.de", false, false);
      IBuild b = new D3arDiablo.Build.Build("SerializedBuild", new Dictionary<D3arDiablo.Build.Slot, IItem>
      {
        {D3arDiablo.Build.Slot.Head, helmOfSerialization}
      });
      Dictionary<CharacterClass, IEnumerable<IBuild>> builds = new Dictionary<CharacterClass, IEnumerable<IBuild>>
      {
        {
          CharacterClass.Wizard, new List<IBuild>
          {
            b
          }
        },
        {CharacterClass.Crusader, new List<IBuild>()},
        {CharacterClass.DemonHunter, new List<IBuild>()},
        {CharacterClass.Barbarian, new List<IBuild>()},
        {CharacterClass.Monk, new List<IBuild>()},
        {CharacterClass.WitchDoctor, new List<IBuild>()},
      };
      string targetPath = TestContext.CurrentContext.TestDirectory + "/serialized.xml";
      
      _serializer.Serialize(builds, targetPath);

      FileAssert.Exists(targetPath, "XML file was created");
      string ns = "{http://inc47.de/BuildSchema}";
      IBuildSerializer deserializer = new BuildSerializer();
      IDictionary<CharacterClass, IEnumerable<IBuild>> deserialized = deserializer.Deserialize(targetPath);
      Assert.AreEqual(6, deserialized.Keys.Count);
      IBuild deserializedBuild = deserialized[CharacterClass.Wizard].First();
      Assert.AreEqual("SerializedBuild", deserializedBuild.Name);
      IItem deserializedItem = deserializedBuild.GetItem(D3arDiablo.Build.Slot.Head);
      Assert.AreEqual(helmOfSerialization.Name, deserializedItem.Name, "Should have equal name");
      Assert.AreEqual(helmOfSerialization.Url, deserializedItem.Url, "Should have equal URL");
      Assert.AreEqual(helmOfSerialization.Ancient, deserializedItem.Ancient, "Should both not be required ancient");
      Assert.AreEqual(helmOfSerialization.Found, deserializedItem.Found, "Should both not be found");
      Assert.IsTrue(deserializedItem.Equals(helmOfSerialization));
    }
  }
}
