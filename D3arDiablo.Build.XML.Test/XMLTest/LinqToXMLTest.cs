using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;

namespace D3arDiablo.Build.XML.Test.XMLTest
{
  public class LinqToXmlTest
  {
    private readonly string _pureNamespace = "http://inc47.de/BuildSchema";
    private readonly string _namespace = "{http://inc47.de/BuildSchema}";

    private XElement root;

    [SetUp]
    public void Setup()
    {
      root = XElement.Load(TestContext.CurrentContext.TestDirectory + "/Resources/BuildExample.xml");
    }

    [Test]
    public void TestAccessNamespaceFromFile()
    {
      Assert.AreEqual(_pureNamespace, root.GetDefaultNamespace().ToString());
    }
    [Test]
    public void TestLoadXmlFromFile()
    {
      Assert.AreEqual(_namespace+"Classes", root.Name.ToString());
    }

    [Test]
    public void TestLoadItemFromFile()
    {
      string itemName = root.Descendants(_namespace+"Crusader")
        .Descendants(_namespace + "Build")
        .Where(b => b.Descendants(_namespace + "Name").First().Value.Equals("LoN"))
        .Descendants(_namespace + "Shoulder")
        .Descendants(_namespace + "Item")
        .Descendants(_namespace + "Name")
        .First()
        .Value;
      Assert.AreEqual("Death Watch Mantle", itemName);
    }
  }
}
