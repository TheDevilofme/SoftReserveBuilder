using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Model.Abstract;

namespace WishlistManaging.Model;
public class ItemPriority : AbstractItem
{

    public List<Priority> PriorityList { get; set; }
    public int ItemWeight { get; set; }
}
