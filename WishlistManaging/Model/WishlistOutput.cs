using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model;
public class WishlistOutput
{
    public List<Player> PlayerEnumerable { get; set; }
    public List<Item> ItemEnumerable { get; set; }
    public List<WishlistedItem> WishlistedItemEnumerable { get; set; }
}
