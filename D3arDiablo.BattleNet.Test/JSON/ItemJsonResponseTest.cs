using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3arDiablo.BattleNet.JSON;
using D3arDiablo.BattleNet.JSON.Item;
using NUnit.Framework;

namespace D3arDiablo.BattleNet.Test.JSON
{
  public class ItemJsonResponseTest
  {
    private IItemJsonResponse _sut;
    private readonly string _testFile = TestContext.CurrentContext.TestDirectory + "/JSON/TestResources/item-json.txt";

    [SetUp]
    public void Setup()
    {
      _sut = new ItemJsonResponse();
    }

    [Test]
    public void TestInitialState()
    {
      Assert.AreEqual(ResponseState.Invalid, _sut.State, "State should be 'Invalid' initially");
    }

    [Test]
    public void TestIncompleteJsonString()
    {
      string jsonString = File.ReadAllText(_testFile);
      string incompleteJsonString = jsonString.Substring(0, jsonString.Length / 2);

      _sut.SetJsonData(incompleteJsonString);

      Assert.AreEqual(ResponseState.Incomplete, _sut.State, "'Incomplete' state on incomplete data");
      Assert.Null(_sut.Icon, "Should return null for any property");
    }

    [Test]
    public void TestNullData()
    {
      _sut.SetJsonData(null);
      Assert.AreEqual(ResponseState.NoData, _sut.State, "Response state should reflect missing data");
    }

    [Test]
    public void TestIcon()
    {
      string jsonString = File.ReadAllText(_testFile);
      _sut.SetJsonData(jsonString);
      Assert.AreEqual(ResponseState.Ok, _sut.State, "Should have completed state");
      Assert.AreEqual("unique_helm_010_x1_demonhunter_male", _sut.Icon, "Icon property should contain expected value");
    }
  }
}
