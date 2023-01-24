using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model;
public class DeltaOfPriorityLists
{
    public HashSet<ItemPriority>? AddedItemPriorities { get; set; }
    public HashSet<ItemPriority>? RemovedItemPriorities { get; set; }
}
