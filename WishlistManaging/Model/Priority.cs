using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WishlistManaging.Model;
public class Priority : WishlistedItem
{

    public bool Active { get; set; }
    public int PriorityWeight { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (!(obj is Priority)) return false;
        Priority priority = obj as Priority ?? new Priority();
        return base.Player_Name == priority.Player_Name && base.Item_Id == priority.Item_Id && Active == priority.Active;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Player_Name, Item_Id, Active);
    }
}
