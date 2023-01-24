using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistManaging.Model;
internal class PriorityCsvOutput
{
    public int Item_Id { get; set; }
    public string Item_Name { get; set; }
    public string Player_Name { get; set; }
    public int Wishlist_Order { get; set; }
    public bool Active { get; set; }
    public int ItemWeight { get; set; }
    public int PriorityWeight { get; set; }
}
