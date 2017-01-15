using System;
using System.Net;
using System.Text;
using D3arDiablo.BattleNet.JSON;
using D3arDiablo.BattleNet.JSON.Item;
using D3arDiablo.Build;

namespace D3arDiablo.BattleNet
{
  public class ItemImageDownloader : IItemImageDownloader
  {
    public void DownloadImage(IItem item, string targetFilePath)
    {
      IItemJsonRequest request = new ItemJsonRequest();
      request.SetData(ExtractItemIdentifier(item.Url));
      request.Submit();
      if (request.Response.State != ResponseState.Ok)
      {
        return;
      }
      IItemJsonResponse response = request.Response;
      Uri imageUri = GenerateImageUri(response);
      using (WebClient client = new WebClient())
      {
        client.DownloadFile(imageUri,targetFilePath);
      }
    }

    private Uri GenerateImageUri(IItemJsonResponse response)
    {
      StringBuilder b = new StringBuilder();
      b.Append("http://media.blizzard.com/d3/icons/items/large/");
      b.Append(response.Icon);
      b.Append(".png");
      return new Uri(b.ToString(), UriKind.Absolute);
    }

    private string ExtractItemIdentifier(string url)
    {
      return url.Substring(url.LastIndexOf("/")+1);
    }
  }
}
