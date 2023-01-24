using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model.CSVMaps;
internal class ItemCsvMap : ClassMap<Item>
{
    public ItemCsvMap()
    {
        Map(item => item.Name).Name("item_name");
        Map(item => item.Id).Name("item_id");
    }
}
