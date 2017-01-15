using System.Net;
using System.Text;
using log4net;

namespace D3arDiablo.BattleNet.JSON.Item
{
  public class ItemJsonRequest : IItemJsonRequest
  {
    private ILog _log = LogManager.GetLogger(typeof(ItemJsonRequest));
    private string _data = null;

    public ItemJsonRequest()
    {
      Response = new ItemJsonResponse();
    }

    public void SetData(string data)
    {
      _data = data;
    }

    public void Submit()
    {
      if (string.IsNullOrEmpty(_data))
      {
        Response.SetJsonData(string.Empty);
        return;
      }
      string json;
      string url = BuildRequestUrl();
      using (WebClient client = new WebClient())
      {
        try
        {
          json = client.DownloadString(url);
        }
        catch (WebException exception)
        {
          _log.Error(string.Format("JSON request to '{0}' failed with client error: {1}", url, exception.Message));
          json = string.Empty;
        }
      }
      Response.SetJsonData(json);
    }

    public IItemJsonResponse Response { get; private set; }

    private string BuildRequestUrl()
    {
      StringBuilder b = new StringBuilder("https://eu.api.battle.net/d3/data/item/");
      b.Append(_data);
      b.Append("?locale=en_GB&apikey=***REMOVED***");
      return b.ToString();
    }
  }
}
