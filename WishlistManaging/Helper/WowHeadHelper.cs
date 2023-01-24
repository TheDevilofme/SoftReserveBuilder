using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WishlistManaging.Model;

namespace WishlistManaging.Helper;
public class WowHeadHelper
{
    private static readonly string r_BaseItemRequestUrl = "https://www.wowhead.com/wotlk/item=";
    private static readonly string r_BaseRequestXmlEnding = "&xml";
    public static async Task FillItemDataFromWowHead(List<Item> itemList)
    {
        HttpClient httpClient = new HttpClient();
        List<Task<HttpResponseMessage>> responseTaskList = new List<Task<HttpResponseMessage>>();
        for (int i = 0; i < itemList.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(itemList[i].Name))
            {
                responseTaskList.Add(httpClient.GetAsync(r_BaseItemRequestUrl + itemList[i].Id + r_BaseRequestXmlEnding));
            }
        }
        Dictionary<int, string> itemNameDict = new Dictionary<int, string>();
        HttpResponseMessage[] httpResponseMessages = await Task.WhenAll(responseTaskList);
        foreach (var httpResponseMessage in httpResponseMessages)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                XDocument xdoc = XDocument.Parse(await httpResponseMessage.Content.ReadAsStringAsync());
                string name = xdoc.Element("wowhead")?.Element("item")?.Element("name")?.Value ?? string.Empty;
                int id = 0;
                int.TryParse(xdoc.Element("wowhead")?.Element("item")?.Attribute("id")?.Value ?? "0", out id);
                itemNameDict.Add(id, name);
            }
        }
        for (int i = 0; i < itemList.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(itemList[i].Name))
            {
                if(itemNameDict.TryGetValue(itemList[i].Id, out string name)) {
                    itemList[i].Name = name;
                }
            }
        }
    }
}
