using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Helper;
using WishlistManaging.Model;
using WishlistManaging.Model.CSVMaps;

namespace WishlistManaging.WishlistReader;
public class WishlistReaderFacade
{
    public static HashSet<Player> GetPlayerWithWishlistedItemsFromCSV(string csvString, List<WishlistedItem> wishlistedItems)
    {
        HashSet<Player> playerHashSet;
        using (var reader = new StringReader(csvString))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PlayerCsvMap>();
                
                playerHashSet = csv.GetRecords<Player>().ToHashSet();
            }
        }
        
        foreach (var player in playerHashSet)
        {
            var wishlistedItemsOfPlayer = wishlistedItems.Where(wishlistedItem => wishlistedItem.Player_Name.Equals(player.Name));
            player.Wishlist = wishlistedItemsOfPlayer.ToList();
        }
        return playerHashSet;
    }

    public static List<WishlistedItem> GetWishlistedItemsFromCSV(string csvString)
    {
        List<WishlistedItem> wishList;
        using (var reader = new StringReader(csvString))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<WishlistedItemCsvMap>();

                wishList = csv.GetRecords<WishlistedItem>().ToList();
            }
        }
        return wishList;
    }

    public static HashSet<Item> GetItemsWithWishlistFromCSV(string csvString, List<WishlistedItem> wishlistedItems) {
        HashSet<Item> itemHashSet;
        using (var reader = new StringReader(csvString))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ItemCsvMap>();

                itemHashSet = csv.GetRecords<Item>().ToHashSet();
            }
        }

        foreach (var item in itemHashSet)
        {
            var wishlistedItemsOfItem = wishlistedItems.Where(wishlistedItem => wishlistedItem.Item_Id == item.Id);
            item.WishlistItems = wishlistedItemsOfItem.ToList();
        }
        return itemHashSet;

    }

    public static async Task<WishlistOutput> GetWishlistOutputFromCSVAsync(string csvPath)
    {
        string csvString = await File.ReadAllTextAsync(csvPath);
        List<WishlistedItem> wishList = GetWishlistedItemsFromCSV(csvString);
        return GetWishlistOutput(csvString, wishList);
    }

    private static WishlistOutput GetWishlistOutput(string csvString, List<WishlistedItem> wishlist)
    {
        HashSet<Player> playerHashSet = GetPlayerWithWishlistedItemsFromCSV(csvString, wishlist);
        HashSet<Item> itemHashSet = GetItemsWithWishlistFromCSV(csvString, wishlist);
        WishlistOutput fullOutput = new WishlistOutput()
        {
            ItemEnumerable = itemHashSet.ToList(),
            PlayerEnumerable = playerHashSet.ToList(),
            WishlistedItemEnumerable = wishlist
        };
        return fullOutput;
    }
}
