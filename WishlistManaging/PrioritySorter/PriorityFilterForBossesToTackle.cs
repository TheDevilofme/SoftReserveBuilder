using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Enum;
using WishlistManaging.Helper;
using WishlistManaging.Model;

namespace WishlistManaging.PrioritySorter;
public class PriorityFilterForBossesToTackle
{
    internal void FilterWishlistForBossesThatAreDone(WishlistOutput wishlistOutput, HashSet<BossEnum> bosses, RaidModeEnum raidMode)
    {
        ILootTableBuilder lootTableBuilder = new UlduarLootTableBuilder(raidMode);
        HashSet<int> possibleItemsToDrop = new HashSet<int>();
        foreach (BossEnum boss in bosses)
        {
            possibleItemsToDrop = possibleItemsToDrop.Concat(lootTableBuilder.LootTableDict[boss].LootTableItemIds).ToHashSet();
        }
        List<WishlistedItem> wishlistedItems = wishlistOutput.WishlistedItemEnumerable.Where(wishlistedItem => possibleItemsToDrop.Contains(wishlistedItem.Item_Id)).ToList();
        wishlistOutput.WishlistedItemEnumerable = wishlistedItems;

    }
}