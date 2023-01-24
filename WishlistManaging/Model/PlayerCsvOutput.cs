using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model;
public class PlayerCsvOutput
{
    public string Name { get; set; }
    public string CharacterClass { get; set; }
    public bool IsAlt { get; set; }
    public string RaidGroup { get; set; }
    public int WishlistedItemsCount { get; set; }

    public PlayerCsvOutput() { }

    public PlayerCsvOutput(string name, string characterClass, bool isAlt, string raidGroup, int wishlistedItemsCount)
    {
        Name = name;
        CharacterClass = characterClass;
        IsAlt = isAlt;
        RaidGroup = raidGroup;
        WishlistedItemsCount = wishlistedItemsCount;
    }

    public override bool Equals(object? obj)
    {
        if (obj is PlayerCsvOutput)
        {
            PlayerCsvOutput player = (PlayerCsvOutput)obj;
            return player.Name.Equals(this.Name);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}
