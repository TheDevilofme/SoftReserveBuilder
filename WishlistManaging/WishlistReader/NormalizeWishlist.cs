using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Model;

namespace WishlistManaging.WishlistReader;
public class NormalizeWishlist
{
    Dictionary<int, int> ItemsToReplace;

    public NormalizeWishlist(List<TiersetItemToken> tiersetItemTokens) {
        ItemsToReplace = tiersetItemTokens.ToDictionary(tiersetItemToken => tiersetItemToken.Item_Id, tiersetItemToken => tiersetItemToken.Token_Id);
    }

    public void NormalizeWishlistedList(List<WishlistedItem> wishlistedItems)
    {
        for (int i = 0; i < wishlistedItems.Count; i++)
        {
            if (ItemsToReplace.TryGetValue(wishlistedItems[i].Item_Id, out int tokenId))
            {
                wishlistedItems[i].Item_Id = tokenId;
            }
        }
    }

    public List<Item> GetNormalizedItemList(List<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (ItemsToReplace.TryGetValue(items[i].Id, out int tokenId))
            {
                items[i].Id = tokenId;
            }
        }
        IEnumerable<IGrouping<int, Item>> groupedItems = items.GroupBy(item => item.Id);
        List<Item> normalizedItems = groupedItems
            .Select(group => new Item() 
            { 
                Id = group.Key, 
                Name = string.Empty, 
                WishlistItems = group
                .Select(item => item.WishlistItems)
                .Aggregate((wishlistItems, nextWishlistItems) => wishlistItems
                .Concat(nextWishlistItems)
                .ToList()) })
            .ToList();
        for (int i = 0; i < normalizedItems.Count; i++)
        {
            Item? item = groupedItems.FirstOrDefault(group => group.Key == normalizedItems[i].Id && group.Count() <= 1)?.First();
            if (item != null)
            {
                normalizedItems[i].Name = item.Name;
            }
        }
        return normalizedItems;
    }

    public void NormalizePlayer(List<Player> player)
    {
        for (int i = 0; i < player.Count; i++)
        {
            NormalizeWishlistedList(player[i].Wishlist);
        }
    }

    public void NormalizeWishlistOutput(WishlistOutput wishlistOutput)
    {
        NormalizeWishlistedList(wishlistOutput.WishlistedItemEnumerable);
        wishlistOutput.ItemEnumerable = GetNormalizedItemList(wishlistOutput.ItemEnumerable);
        NormalizePlayer(wishlistOutput.PlayerEnumerable);
    }


}
