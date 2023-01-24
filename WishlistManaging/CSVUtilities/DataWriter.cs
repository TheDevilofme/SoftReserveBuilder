using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Model;

namespace WishlistManaging.CSVUtilities;
public class DataWriter
{
    public static void WritePlayerCsv(IEnumerable<Player> players, string path)
    {
        using (var writer = new StreamWriter(path))
        {
            using (CsvWriter csv = new(writer, CultureInfo.InvariantCulture))
            {
                IEnumerable<PlayerCsvOutput> playerCsvOutput = players.Select(p => new PlayerCsvOutput(p.Name, p.CharacterClass, p.IsAlt, p.RaidGroup, p.Wishlist.Count));
                csv.WriteRecords(playerCsvOutput);
            }
        }
    }

    public static void WritePriorityCsv(IEnumerable<ItemPriority> itemPriorities, string path)
    {
        List<PriorityCsvOutput> priorityCsvOutputs = new List<PriorityCsvOutput>();
        foreach (var itemPriority in itemPriorities)
        {
            foreach (var priority in itemPriority.PriorityList)
            {
                priorityCsvOutputs.Add(new PriorityCsvOutput { Active = priority.Active, PriorityWeight = priority.PriorityWeight, Wishlist_Order = priority.Order, Item_Id = priority.Item_Id, Player_Name = priority.Player_Name, Item_Name = itemPriority.Name, ItemWeight = itemPriority.ItemWeight });
            }
        }

        using (var writer = new StreamWriter(path))
        {
            using (CsvWriter csv = new(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(priorityCsvOutputs);
            }
        }
    }
}
