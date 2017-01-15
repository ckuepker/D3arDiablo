namespace D3arDiablo.BattleNet.JSON.Item
{
  public interface IItemJsonResponse
  {
    ResponseState State { get; }
    string Icon { get; }
    void SetJsonData(string jsonString);
  }
}