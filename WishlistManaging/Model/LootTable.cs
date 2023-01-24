using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Enum;

namespace WishlistManaging.Model;
public class LootTable
{
    public readonly BossEnum Boss;
    public readonly HashSet<int> LootTableItemIds;

    public LootTable(BossEnum boss, IEnumerable<int> lootTableItemIds)
    {
        this.Boss = boss;
        this.LootTableItemIds = lootTableItemIds.ToHashSet();
    }

    public override int GetHashCode()
    {
        return Boss.GetHashCode();
    }
}
