using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model.CSVMaps;
internal class PlayerCsvMap : ClassMap<Player>
{
    public PlayerCsvMap()
    {
        Map(player => player.Name).Name("character_name");
        Map(player => player.CharacterClass).Name("character_class");
        Map(player => player.IsAlt).Name("character_is_alt");
        Map(player => player.RaidGroup).Name("raid_group_name");
    }
}
