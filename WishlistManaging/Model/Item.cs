using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Model.Abstract;

namespace WishlistManaging.Model;
public class Item : AbstractItem
{
    public List<WishlistedItem> WishlistItems { get; set; }
}
