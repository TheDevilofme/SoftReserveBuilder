using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model;
public class Player
{
    public string Name { get; set; }
    public string CharacterClass { get; set; }
    public bool IsAlt { get; set; }
    public string RaidGroup { get; set; }
    public List<WishlistedItem> Wishlist { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Player)
        {
            Player player = (Player)obj;
            return player.Name.Equals(this.Name);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}
