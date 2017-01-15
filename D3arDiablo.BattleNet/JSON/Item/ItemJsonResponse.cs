using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace D3arDiablo.BattleNet.JSON.Item
{
  public class ItemJsonResponse : IItemJsonResponse
  {
    private JObject _json;

    public ItemJsonResponse()
    {
      State = ResponseState.Invalid;
    }



    public ResponseState State { get; private set; }

    public string Icon
    {
      get
      {
        if (State != ResponseState.Ok)
        {
          return null;
        }
        return (string)_json["icon"];
      }
    }

    public void SetJsonData(string jsonString)
    {
      if (string.IsNullOrEmpty(jsonString))
      {
        State = ResponseState.NoData;
        return;
      }
      try
      {
        _json = JObject.Parse(jsonString);
        State = ResponseState.Ok;
      }
      catch (JsonReaderException exception)
      {
        _json = null;
        State = ResponseState.Incomplete;
      }
    }
  }
}
