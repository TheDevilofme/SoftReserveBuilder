using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WishlistManaging.Model;

namespace WishlistManaging.Helper;
public class TierSetItemCreator
{
    public static async Task<List<TiersetItemToken>> GetTierSetItemTokenReplacementListFromSQLScript(string path)
    {
        List<TiersetItemToken> tiersetItemTokens = new List<TiersetItemToken>();
        var sqltext = await File.ReadAllTextAsync(path);
        Regex getRowItemAndParentItemId = new(@".*`parent_item_id` = (\d+) WHERE `item_id` = (\d+).*");
        MatchCollection matchCollection = getRowItemAndParentItemId.Matches(sqltext);
        foreach (Match match in matchCollection)
        {
            TiersetItemToken tiersetItemToken = new();
            tiersetItemToken.Token_Id = int.Parse(match.Groups[1].Value);
            tiersetItemToken.Item_Id = int.Parse(match.Groups[2].Value);
            tiersetItemTokens.Add(tiersetItemToken);
        }
        return tiersetItemTokens;
    }

    public static async Task<List<TiersetItemToken>> GetTierSetItemTokenReplacementListFromJson(string path)
    {
        FileStream jsonStream = File.OpenRead(path);
        List<TiersetItemToken> tiersetItemTokens = await JsonSerializer.DeserializeAsync<List<TiersetItemToken>>(jsonStream);
        return tiersetItemTokens;
    }

    public static async void CreateTierSetItemTokenReplacementListJson(List<TiersetItemToken> tiersetItemTokens, string path)
    {
        using (FileStream fileStream = File.OpenWrite(path))
        {
            await JsonSerializer.SerializeAsync(fileStream, tiersetItemTokens);
        }
    }
}
