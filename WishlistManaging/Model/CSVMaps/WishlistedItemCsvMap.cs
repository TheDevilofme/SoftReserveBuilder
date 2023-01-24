using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model.CSVMaps;
internal class WishlistedItemCsvMap : ClassMap<WishlistedItem>
{
    public WishlistedItemCsvMap()
    {
        Map(wishlistedItem => wishlistedItem.Player_Name).Name("character_name");
        Map(wishlistedItem => wishlistedItem.Item_Id).Name("item_id");
        Map(wishlistedItem => wishlistedItem.Order).Name("sort_order");
    }
}
