using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model.Abstract;
public abstract class AbstractItem
{

    public int Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Item)
        {
            var item = (Item)obj;
            return item.Id == Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
