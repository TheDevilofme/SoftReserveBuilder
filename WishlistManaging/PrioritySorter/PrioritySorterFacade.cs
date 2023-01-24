using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Enum;
using WishlistManaging.Model;

namespace WishlistManaging.PrioritySorter;
public class PrioritySorterFacade
{
    public static List<ItemPriority> GetPriorityOutput(WishlistOutput wishlistOutput, int amountSoftReserve, int limitAmountOfPeopleReserving)
    {
        List<ItemPriority> itemPriorityList = wishlistOutput.ItemEnumerable.Select(item => new ItemPriority() { Id = item.Id, Name = item.Name, ItemWeight = item.WishlistItems.Count }).ToList();
        List<Priority> priorityList = wishlistOutput.WishlistedItemEnumerable.Select(wishlistedItem => new Priority() { Item_Id = wishlistedItem.Item_Id, Player_Name = wishlistedItem.Player_Name, Order = wishlistedItem.Order, Active = false }).ToList();
        for (int i = 0; i < priorityList.Count(); i++)
        {
            ItemPriority itemPriority = itemPriorityList.First(priorityItem => priorityItem.Id == priorityList[i].Item_Id);
            priorityList[i].PriorityWeight = itemPriority.ItemWeight + priorityList[i].Order;
        }
        List<Priority> weightedItemPrioritys = priorityList.OrderBy(priority => priority.PriorityWeight).ToList();
        IEnumerable<Priority> activePriorities = GetActivePriorities(weightedItemPrioritys, amountSoftReserve, limitAmountOfPeopleReserving);
        FilterForActivePrioritys(activePriorities, itemPriorityList);
        var test = itemPriorityList.OrderByDescending(test => test.Name).Where(itemPriority => itemPriority.PriorityList.Count > 0).ToList();
        return itemPriorityList.Where(itemPriority => itemPriority.PriorityList.Count > 0).ToList();
    }

    public static void FilterWishlistForBossesThatAreDone(WishlistOutput wishlistOutput, HashSet<BossEnum> bosses, RaidModeEnum raidMode)
    {
        new PriorityFilterForBossesToTackle().FilterWishlistForBossesThatAreDone(wishlistOutput, bosses, raidMode);
    }

    public static void NormalizeWishlistedItems(WishlistOutput wishlistOutput)
    {
        List<WishlistedItem> wishlistedItems = wishlistOutput.WishlistedItemEnumerable;
        List<WishlistedItem> normalizedWishlistedItems = new List<WishlistedItem>();
        IEnumerable<IGrouping<string, WishlistedItem>> wishlistedItemsGroupedByPlayer = wishlistedItems.GroupBy(wishlistedItem => wishlistedItem.Player_Name);
        foreach (var wishlistedItemsGroup in wishlistedItemsGroupedByPlayer)
        {
            WishlistedItem[] wishlistedItemsGroupArray = wishlistedItemsGroup.OrderBy(wishlistedItem => wishlistedItem.Order).ToArray();
            for (int i = 0; i < wishlistedItemsGroupArray.Length; i++)
            {
                wishlistedItemsGroupArray[i].Order = i + 1;
                normalizedWishlistedItems.Add(wishlistedItemsGroupArray[i]);
            }
        }
        wishlistOutput.WishlistedItemEnumerable = normalizedWishlistedItems;
    }

    private static IEnumerable<Priority> GetActivePriorities(List<Priority> weightedPriorityList, int amountSoftReserves, int limitAmountOfPeopleReserving)
    {
        Dictionary<string, int> playerDict = new Dictionary<string, int>();
        Dictionary<int, int> itemDict = new Dictionary<int, int>();
        for (int i = 0; i < weightedPriorityList.Count; i++)
        {
            Priority priority = weightedPriorityList[i];
            int amountOfReservedItemsForPlayer = 0;
            int amountOfReservedPlayersForItem = 0;
            if (!playerDict.TryGetValue(priority.Player_Name, out amountOfReservedItemsForPlayer))
            {
                playerDict.Add(priority.Player_Name, 0);
            }
            if (!itemDict.TryGetValue(priority.Item_Id, out amountOfReservedPlayersForItem))
            {
                itemDict.Add(priority.Item_Id, 0);
            }
            if (amountOfReservedItemsForPlayer < amountSoftReserves && amountOfReservedPlayersForItem < limitAmountOfPeopleReserving)
            {
                priority.Active = true;
                amountOfReservedItemsForPlayer++;
                amountOfReservedPlayersForItem++;
                playerDict[priority.Player_Name] = amountOfReservedItemsForPlayer;
                itemDict[priority.Item_Id] = amountOfReservedPlayersForItem;
            }
            else
            {
                priority.Active = false;
            }
        }
        if (playerDict.Any(playerAmount => playerAmount.Value < amountSoftReserves))
        {
            IEnumerable<string> playerNamesWithoutAllSoftreserves = playerDict.Where(playerAmount => playerAmount.Value < amountSoftReserves).Select(playerAmount => playerAmount.Key);
            bool playerWithNotEnoughReservesExists = false;
            foreach (var playerName in playerNamesWithoutAllSoftreserves)
            {
                if(weightedPriorityList.Count(priority => priority.Player_Name.Equals(playerName)) >= amountSoftReserves) { 
                    playerWithNotEnoughReservesExists = true;
                    break;
                }

            }
            if (playerWithNotEnoughReservesExists)
            {
                GetActivePriorities(weightedPriorityList, amountSoftReserves, limitAmountOfPeopleReserving + 1);
            }
        }
        IEnumerable<Priority> activePriorities = weightedPriorityList.Where(priority => priority.Active);
        var test = activePriorities.GroupBy(test2 => test2.Player_Name);
        return activePriorities;

    }

    private static void FilterForActivePrioritys(IEnumerable<Priority> activePriorities, List<ItemPriority> itemPriorities) {
        IEnumerable<IGrouping<int, Priority>> groupedActivePriorities = activePriorities.GroupBy(priority => priority.Item_Id);
        for (int i = 0; i < itemPriorities.Count; i++)
        {
            List<Priority> itemPriorityList = groupedActivePriorities.FirstOrDefault(group => group.Key == itemPriorities[i].Id)?.ToList() ?? new List<Priority>();
            itemPriorities[i].PriorityList = itemPriorityList;
        }
    }

    public static DeltaOfPriorityLists GetDeltaOfItemPriorityLists(IEnumerable<ItemPriority> newItemPriorities, IEnumerable<ItemPriority> archivedItemPriorities) {
        HashSet<ItemPriority> addedPriorities = GetDeltaOfItemPriorityList(newItemPriorities, archivedItemPriorities);
        HashSet<ItemPriority> removedPriorities = GetDeltaOfItemPriorityList(archivedItemPriorities, newItemPriorities);
        return new DeltaOfPriorityLists() { AddedItemPriorities= addedPriorities, RemovedItemPriorities= removedPriorities };
    }

    private static HashSet<ItemPriority> GetDeltaOfItemPriorityList(IEnumerable<ItemPriority> itemPriorities1, IEnumerable<ItemPriority> itemPriorities2)
    {
        HashSet<ItemPriority> addedPriorities = new();
        foreach (var itemPriority1 in itemPriorities1)
        {
            ItemPriority? itemPriority2 = itemPriorities2.FirstOrDefault(aP => aP.Id == itemPriority1.Id);
            if (itemPriority2 != null)
            {
                foreach (var priority1 in itemPriority1.PriorityList)
                {
                    if (!itemPriority2.PriorityList.Contains(priority1))
                    {
                        ItemPriority? itemPriority = addedPriorities.FirstOrDefault(aP => aP.Id == itemPriority1.Id);
                        if (itemPriority == null)
                        {
                            itemPriority = new ItemPriority();
                            itemPriority.Id = itemPriority1.Id;
                            itemPriority.Name = itemPriority1.Name;
                            itemPriority.ItemWeight = itemPriority1.ItemWeight;
                            itemPriority.PriorityList = new List<Priority>();
                            addedPriorities.Add(itemPriority);
                        }
                        itemPriority.PriorityList.Add(priority1);
                    }
                }
            }
            else
            {
                addedPriorities.Add(itemPriority1);
            }
        }
        return addedPriorities;
    }
}
