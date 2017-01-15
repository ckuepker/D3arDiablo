using System.Security.Cryptography.X509Certificates;

namespace D3arDiablo.BattleNet.JSON.Item
{
  public interface IItemJsonRequest
  {
    void SetData(string data);
    void Submit();
    IItemJsonResponse Response { get; }
  }
}
