using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace D3arDiablo.Build.XML.Test
{
  public class BuildSerializerTest
  {
    private string exampleFile = TestContext.CurrentContext.TestDirectory+"/Resources/BuildExample.xml";
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
  }
}
