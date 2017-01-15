using D3arDiablo.BattleNet.JSON;
using D3arDiablo.BattleNet.JSON.Item;
using D3arDiablo.Build;
using NUnit.Framework;

namespace D3arDiablo.BattleNet.Test.JSON
{
  public class ItemJsonRequestTest
  {
    private IItemJsonRequest _request;

    [SetUp]
    public void Setup()
    {
      _request = new ItemJsonRequest();
    }

    [Test]
    public void TestNoData()
    {
      _request.Submit();
      IItemJsonResponse response = _request.Response;

      Assert.NotNull(response, "Response should not be null");
      Assert.AreEqual(ResponseState.NoData, response.State, "Request should fail because no data was provided");
    }

    [Test]
    public void TestGetItemIcon()
    {
      IItem i = new Item("Tal Rasha's Guise of Wisdom", "http://us.battle.net/d3/en/item/tal-rashas-guise-of-wisdom", false, false);
      _request.SetData("tal-rashas-guise-of-wisdom");
      _request.Submit();
      IItemJsonResponse response = _request.Response;

      Assert.NotNull(response, "Response should not be null");
      Assert.AreEqual(ResponseState.Ok, response.State, "Response should have succeeded");
    }
  }
}
