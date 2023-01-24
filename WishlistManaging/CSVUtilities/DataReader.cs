using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Model.CSVMaps;
using WishlistManaging.Model;

namespace WishlistManaging.CSVUtilities;
public class DataReader
{
    public static IEnumerable<ItemPriority> GetItemPriorityFromCSV(string csvString)
    {
        List<ItemPriority> itemPriorityList = new();
        HashSet<PriorityCsvOutput> priorityCsvOutputs;
        using (var reader = new StringReader(csvString))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                priorityCsvOutputs = csv.GetRecords<PriorityCsvOutput>().ToHashSet();
            }
        }

        foreach (var priorityCsvOutput in priorityCsvOutputs)
        {
            ItemPriority itemPriorityForName = itemPriorityList.FirstOrDefault(itemPriority => itemPriority.Name == priorityCsvOutput.Item_Name);
            if (itemPriorityForName == null)
            {
                itemPriorityForName= new ItemPriority();
                itemPriorityForName.Id = priorityCsvOutput.Item_Id;
                itemPriorityForName.Name = priorityCsvOutput.Item_Name;
                itemPriorityForName.ItemWeight = priorityCsvOutput.ItemWeight;
                itemPriorityForName.PriorityList = new List<Priority>();
                itemPriorityList.Add(itemPriorityForName);
            }
            Priority priority = new();
            priority.Active= priorityCsvOutput.Active;
            priority.PriorityWeight = priorityCsvOutput.PriorityWeight;
            priority.Order = priorityCsvOutput.Wishlist_Order;
            priority.Item_Id= priorityCsvOutput.Item_Id;
            priority.Player_Name = priorityCsvOutput.Player_Name;
            itemPriorityForName.PriorityList.Add(priority);
        }
        return itemPriorityList;
    }

    public static async Task<IEnumerable<ItemPriority>> GetItemPriorityFromCSVAsync(string csvPath)
    {
        string csvString = await File.ReadAllTextAsync(csvPath);
        return GetItemPriorityFromCSV(csvString);
    }
}
