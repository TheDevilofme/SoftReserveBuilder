using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Enum;
using WishlistManaging.Helper;

namespace WishlistManaging.Model;
public interface ILootTableBuilder
{
    Dictionary<BossEnum, LootTable> LootTableDict { get;}
}
