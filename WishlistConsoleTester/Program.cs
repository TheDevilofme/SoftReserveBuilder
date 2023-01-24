// See https://aka.ms/new-console-template for more information
using WishlistManaging.CSVUtilities;
using WishlistManaging.Enum;
using WishlistManaging.Helper;
using WishlistManaging.Model;
using WishlistManaging.PrioritySorter;
using WishlistManaging.WishlistReader;

var csvPath = "./wishlist-export.csv";
var sqlPath = "./link_tokens.sql";
var jsonTierTokenPath = "./link_tokens.json";
var bossesWeTackle = new HashSet<BossEnum>() {
    BossEnum.FlameLeviathan,
    BossEnum.Ignis,
    BossEnum.Razorscale,
    BossEnum.XT,
    BossEnum.IronCouncil,
    BossEnum.Kologarn,
    BossEnum.Auriaya,
    BossEnum.Hodir,
    BossEnum.Thorim,
    BossEnum.Freya,
    BossEnum.Mimiron,
    BossEnum.Vezax,
    BossEnum.Yogg,
    BossEnum.ThorimHard,
    BossEnum.YoggHard ,
    //BossEnum.FlameLeviathanHard,
    //BossEnum.XTHard,
    //BossEnum.IronCouncilHard,
    //BossEnum.HodirHard,
    //BossEnum.FreyaHard,
    //BossEnum.MimironHard, 
    //BossEnum.VezaxHard
};


List<TiersetItemToken> tiersetItemTokens;

if (!new FileInfo(jsonTierTokenPath).Exists)
{
    tiersetItemTokens = await TierSetItemCreator.GetTierSetItemTokenReplacementListFromSQLScript(sqlPath);
    TierSetItemCreator.CreateTierSetItemTokenReplacementListJson(tiersetItemTokens, jsonTierTokenPath);
}
else
{
    tiersetItemTokens = await TierSetItemCreator.GetTierSetItemTokenReplacementListFromJson(jsonTierTokenPath);
}

WishlistOutput wishlistOutput = await WishlistReaderFacade.GetWishlistOutputFromCSVAsync(csvPath);

NormalizeWishlist wishlistNormalizer = new(tiersetItemTokens);
wishlistNormalizer.NormalizeWishlistOutput(wishlistOutput);
await WowHeadHelper.FillItemDataFromWowHead(wishlistOutput.ItemEnumerable);
PrioritySorterFacade.FilterWishlistForBossesThatAreDone(wishlistOutput, bossesWeTackle, RaidModeEnum.TwentyFiveMan);
//PrioritySorterFacade.NormalizeWishlistedItems(wishlistOutput);
List<ItemPriority> ItemPriorities = PrioritySorterFacade.GetPriorityOutput(wishlistOutput, 3, 2);
var finalPlayersAlreadyEntered = wishlistOutput.PlayerEnumerable.Where(player => !player.IsAlt && player.RaidGroup.Equals("Main Raid"));
DataWriter.WritePlayerCsv(finalPlayersAlreadyEntered, "./wishlist-players-entered.csv");
FileInfo fileInfo = new("./item-priorities.csv");
if (fileInfo.Exists)
{
    fileInfo.CopyTo("./archived-item-priorities.csv", true);
}
DataWriter.WritePriorityCsv(ItemPriorities, "./item-priorities.csv");
List<ItemPriority> archivedPriorities = (await DataReader.GetItemPriorityFromCSVAsync("./archived-item-priorities.csv")).ToList();

DeltaOfPriorityLists deltaOfPriorityLists = PrioritySorterFacade.GetDeltaOfItemPriorityLists(ItemPriorities, archivedPriorities);
if (deltaOfPriorityLists.RemovedItemPriorities != null)
{
    DataWriter.WritePriorityCsv(deltaOfPriorityLists.RemovedItemPriorities, "./removed-item-priorities.csv");
}
if (deltaOfPriorityLists.AddedItemPriorities != null)
{
    DataWriter.WritePriorityCsv(deltaOfPriorityLists.AddedItemPriorities, "./added-item-priorities.csv");
}
