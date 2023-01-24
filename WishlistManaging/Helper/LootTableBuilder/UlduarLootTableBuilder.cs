using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistManaging.Enum;
using WishlistManaging.Model;

namespace WishlistManaging.Helper;
public class UlduarLootTableBuilder : ILootTableBuilder
{

    public Dictionary<BossEnum, LootTable> LootTableDict { get; }

    public UlduarLootTableBuilder(RaidModeEnum raidModeEnum)
    {
        LootTableDict = new Dictionary<BossEnum, LootTable>();
        if (raidModeEnum == RaidModeEnum.TwentyFiveMan)
        {
            LootTableDict.Add(BossEnum.FlameLeviathan, CreateLootTableFlameLeviathan25());
            LootTableDict.Add(BossEnum.FlameLeviathanHard, CreateLootTableFlameLeviathanHard25());
            LootTableDict.Add(BossEnum.Ignis, CreateLootTableIgnis25());
            LootTableDict.Add(BossEnum.Razorscale, CreateLootTableRazorscale25());
            LootTableDict.Add(BossEnum.XT, CreateLootTableXT25());
            LootTableDict.Add(BossEnum.XTHard, CreateLootTableXTHard25());
            LootTableDict.Add(BossEnum.IronCouncil, CreateLootTableIronCouncil25());
            LootTableDict.Add(BossEnum.IronCouncilHard, CreateLootTableIronCouncilHard25());
            LootTableDict.Add(BossEnum.Algalon, CreateLootTableAlgalon25());
            LootTableDict.Add(BossEnum.Kologarn, CreateLootTableKologarn25());
            LootTableDict.Add(BossEnum.Auriaya, CreateLootTableAuriaya25());
            LootTableDict.Add(BossEnum.Hodir, CreateLootTableHodir25());
            LootTableDict.Add(BossEnum.HodirHard, CreateLootTableHodirHard25());
            LootTableDict.Add(BossEnum.Thorim, CreateLootTableThorim25());
            LootTableDict.Add(BossEnum.ThorimHard, CreateLootTableThorimHard25());
            LootTableDict.Add(BossEnum.Freya, CreateLootTableFreya25());
            LootTableDict.Add(BossEnum.FreyaHard, CreateLootTableFreyaHard25());
            LootTableDict.Add(BossEnum.Mimiron, CreateLootTableMimiron25());
            LootTableDict.Add(BossEnum.MimironHard, CreateLootTableMimironHard25());
            LootTableDict.Add(BossEnum.Vezax, CreateLootTableVezax25());
            LootTableDict.Add(BossEnum.VezaxHard, CreateLootTableVezaxHard25());
            LootTableDict.Add(BossEnum.Yogg, CreateLootTableYogg25());
            LootTableDict.Add(BossEnum.YoggHard, CreateLootTableYoggHard25());
        }
        else if (raidModeEnum == RaidModeEnum.TenMan)
        {
            LootTableDict.Add(BossEnum.FlameLeviathan, CreateLootTableFlameLeviathan10());
            LootTableDict.Add(BossEnum.FlameLeviathanHard, CreateLootTableFlameLeviathanHard10());
            LootTableDict.Add(BossEnum.Ignis, CreateLootTableIgnis10());
            LootTableDict.Add(BossEnum.Razorscale, CreateLootTableRazorscale10());
            LootTableDict.Add(BossEnum.XT, CreateLootTableXT10());
            LootTableDict.Add(BossEnum.XTHard, CreateLootTableXTHard10());
            LootTableDict.Add(BossEnum.IronCouncil, CreateLootTableIronCouncil10());
            LootTableDict.Add(BossEnum.IronCouncilHard, CreateLootTableIronCouncilHard10());
            LootTableDict.Add(BossEnum.Algalon, CreateLootTableAlgalon10());
            LootTableDict.Add(BossEnum.Kologarn, CreateLootTableKologarn10());
            LootTableDict.Add(BossEnum.Auriaya, CreateLootTableAuriaya10());
            LootTableDict.Add(BossEnum.Hodir, CreateLootTableHodir10());
            LootTableDict.Add(BossEnum.HodirHard, CreateLootTableHodirHard10());
            LootTableDict.Add(BossEnum.Thorim, CreateLootTableThorim10());
            LootTableDict.Add(BossEnum.ThorimHard, CreateLootTableThorimHard10());
            LootTableDict.Add(BossEnum.Freya, CreateLootTableFreya10());
            LootTableDict.Add(BossEnum.FreyaHard, CreateLootTableFreyaHard10());
            LootTableDict.Add(BossEnum.Mimiron, CreateLootTableMimiron10());
            LootTableDict.Add(BossEnum.MimironHard, CreateLootTableMimironHard10());
            LootTableDict.Add(BossEnum.Vezax, CreateLootTableVezax10());
            LootTableDict.Add(BossEnum.VezaxHard, CreateLootTableVezaxHard10());
            LootTableDict.Add(BossEnum.Yogg, CreateLootTableYogg10());
            LootTableDict.Add(BossEnum.YoggHard, CreateLootTableYoggHard10());
        }
    }

    private LootTable CreateLootTableFlameLeviathan25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45117);
        lootTable.Add(45119);
        lootTable.Add(45108);
        lootTable.Add(45118);
        lootTable.Add(45109);
        lootTable.Add(45107);
        lootTable.Add(45111);
        lootTable.Add(45116);
        lootTable.Add(45113);
        lootTable.Add(45106);
        lootTable.Add(45112);
        lootTable.Add(45115);
        lootTable.Add(45114);
        lootTable.Add(45110);
        lootTable.Add(45086);
        return new LootTable(BossEnum.FlameLeviathan, lootTable);
    }

    private LootTable CreateLootTableFlameLeviathanHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45135);
        lootTable.Add(45136);
        lootTable.Add(45134);
        lootTable.Add(45133);
        lootTable.Add(45132);
        return new LootTable(BossEnum.FlameLeviathanHard, lootTable);
    }

    private LootTable CreateLootTableIgnis25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45186);
        lootTable.Add(45185);
        lootTable.Add(45162);
        lootTable.Add(45164);
        lootTable.Add(45187);
        lootTable.Add(45167);
        lootTable.Add(45161);
        lootTable.Add(45166);
        lootTable.Add(45157);
        lootTable.Add(45168);
        lootTable.Add(45158);
        lootTable.Add(45169);
        lootTable.Add(45165);
        lootTable.Add(45171);
        lootTable.Add(45170);
        return new LootTable(BossEnum.Ignis, lootTable);
    }

    private LootTable CreateLootTableRazorscale25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45138);
        lootTable.Add(45150);
        lootTable.Add(45146);
        lootTable.Add(45149);
        lootTable.Add(45141);
        lootTable.Add(45151);
        lootTable.Add(45143);
        lootTable.Add(45140);
        lootTable.Add(45139);
        lootTable.Add(45148);
        lootTable.Add(45510);
        lootTable.Add(45144);
        lootTable.Add(45142);
        lootTable.Add(45147);
        lootTable.Add(45137);
        return new LootTable(BossEnum.Razorscale, lootTable);
    }
    private LootTable CreateLootTableXT25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45253);
        lootTable.Add(45258);
        lootTable.Add(45260);
        lootTable.Add(45259);
        lootTable.Add(45249);
        lootTable.Add(45251);
        lootTable.Add(45252);
        lootTable.Add(45248);
        lootTable.Add(45250);
        lootTable.Add(45247);
        lootTable.Add(45254);
        lootTable.Add(45255);
        lootTable.Add(45246);
        lootTable.Add(45256);
        lootTable.Add(45257);
        return new LootTable(BossEnum.XT, lootTable);
    }
    private LootTable CreateLootTableXTHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45446);
        lootTable.Add(45444);
        lootTable.Add(45445);
        lootTable.Add(45443);
        lootTable.Add(45442);
        return new LootTable(BossEnum.XTHard, lootTable);
    }
    private LootTable CreateLootTableIronCouncil25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45224);
        lootTable.Add(45240);
        lootTable.Add(45238);
        lootTable.Add(45237);
        lootTable.Add(45232);
        lootTable.Add(45227);
        lootTable.Add(45239);   
        lootTable.Add(45226);
        lootTable.Add(45225);
        lootTable.Add(45228);
        lootTable.Add(45193);
        lootTable.Add(45236);
        lootTable.Add(45235);
        lootTable.Add(45233);
        lootTable.Add(45234);
        return new LootTable(BossEnum.IronCouncil, lootTable);
    }
    private LootTable CreateLootTableIronCouncilHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45242);
        lootTable.Add(45245);
        lootTable.Add(45244);
        lootTable.Add(45241);
        lootTable.Add(45243);
        lootTable.Add(45607);
        lootTable.Add(45857);
        return new LootTable(BossEnum.IronCouncilHard, lootTable);
    }
    private LootTable CreateLootTableAlgalon25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45665);
        lootTable.Add(45619);
        lootTable.Add(45611);
        lootTable.Add(45616);
        lootTable.Add(45610);
        lootTable.Add(45615);
        lootTable.Add(45594);
        lootTable.Add(45599);
        lootTable.Add(45609);
        lootTable.Add(45620);
        lootTable.Add(45607);
        lootTable.Add(45612);
        lootTable.Add(45613);
        lootTable.Add(45587);
        lootTable.Add(45570);
        lootTable.Add(45617);
        lootTable.Add(46053);
        return new LootTable(BossEnum.Algalon, lootTable);
    }
    private LootTable CreateLootTableKologarn25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45272);
        lootTable.Add(45275);
        lootTable.Add(45273);
        lootTable.Add(45265);
        lootTable.Add(45274);
        lootTable.Add(45264);
        lootTable.Add(45269);
        lootTable.Add(45268);
        lootTable.Add(45267);
        lootTable.Add(45262);
        lootTable.Add(45263);
        lootTable.Add(45271);
        lootTable.Add(45270);
        lootTable.Add(45266);
        lootTable.Add(45261);
        return new LootTable(BossEnum.Kologarn, lootTable);
    }
    private LootTable CreateLootTableAuriaya25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45319);
        lootTable.Add(45435);
        lootTable.Add(45441);
        lootTable.Add(45439);
        lootTable.Add(45325);
        lootTable.Add(45440);
        lootTable.Add(45320);
        lootTable.Add(45334);
        lootTable.Add(45434);
        lootTable.Add(45326);
        lootTable.Add(45438);
        lootTable.Add(45436);
        lootTable.Add(45437);
        lootTable.Add(45315);
        lootTable.Add(45327);
        return new LootTable(BossEnum.Auriaya, lootTable);
    }
    private LootTable CreateLootTableHodir25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45453);
        lootTable.Add(45454);
        lootTable.Add(45452);
        lootTable.Add(45451);
        lootTable.Add(45450);
        lootTable.Add(45632);
        lootTable.Add(45633);
        lootTable.Add(45634);
        return new LootTable(BossEnum.Hodir, lootTable);
    }
    private LootTable CreateLootTableHodirHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45461);
        lootTable.Add(45462);
        lootTable.Add(45460);
        lootTable.Add(45459);
        lootTable.Add(45612);
        lootTable.Add(45457);
        lootTable.Add(45815);
        return new LootTable(BossEnum.HodirHard, lootTable);
    }
    private LootTable CreateLootTableThorim25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45468);
        lootTable.Add(45467);
        lootTable.Add(45469);
        lootTable.Add(45466);
        lootTable.Add(45463);
        lootTable.Add(45638);
        lootTable.Add(45639);
        lootTable.Add(45640);
        return new LootTable(BossEnum.Thorim, lootTable);
    }
    private LootTable CreateLootTableThorimHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45473);
        lootTable.Add(45474);
        lootTable.Add(45472);
        lootTable.Add(45471);
        lootTable.Add(45570);
        lootTable.Add(45470);
        lootTable.Add(45817);
        return new LootTable(BossEnum.ThorimHard, lootTable);
    }
    private LootTable CreateLootTableFreya25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45483);
        lootTable.Add(45482);
        lootTable.Add(45481);
        lootTable.Add(45480);
        lootTable.Add(45479);
        lootTable.Add(45653);
        lootTable.Add(45654);
        lootTable.Add(45655);
        return new LootTable(BossEnum.Freya, lootTable);
    }
    private LootTable CreateLootTableFreyaHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45486);
        lootTable.Add(45488);
        lootTable.Add(45487);
        lootTable.Add(45485);
        lootTable.Add(45484);
        lootTable.Add(45613);
        lootTable.Add(45814);
        return new LootTable(BossEnum.FreyaHard, lootTable);
    }
    private LootTable CreateLootTableMimiron25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45493);
        lootTable.Add(45492);
        lootTable.Add(45491);
        lootTable.Add(45490);
        lootTable.Add(45489);
        lootTable.Add(45641);
        lootTable.Add(45642);
        lootTable.Add(45643);
        return new LootTable(BossEnum.Mimiron, lootTable);
    }
    private LootTable CreateLootTableMimironHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45496);
        lootTable.Add(45497);
        lootTable.Add(45663);
        lootTable.Add(45495);
        lootTable.Add(45494);
        lootTable.Add(45620);
        lootTable.Add(45816);
        return new LootTable(BossEnum.MimironHard, lootTable);
    }
    private LootTable CreateLootTableVezax25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45514);
        lootTable.Add(45508);
        lootTable.Add(45512);
        lootTable.Add(45504);
        lootTable.Add(45513);
        lootTable.Add(45502);
        lootTable.Add(45505);
        lootTable.Add(45501);
        lootTable.Add(45503);
        lootTable.Add(45515);
        lootTable.Add(45507);
        lootTable.Add(45509);
        lootTable.Add(45145);
        lootTable.Add(45498);
        lootTable.Add(45511);
        return new LootTable(BossEnum.Vezax, lootTable);
    }
    private LootTable CreateLootTableVezaxHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45520);
        lootTable.Add(45519);
        lootTable.Add(45517);
        lootTable.Add(45518);
        lootTable.Add(45516);
        return new LootTable(BossEnum.VezaxHard, lootTable);
    }
    private LootTable CreateLootTableYogg25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45529);
        lootTable.Add(45532);
        lootTable.Add(45523);
        lootTable.Add(45524);
        lootTable.Add(45531);
        lootTable.Add(45525);
        lootTable.Add(45530);
        lootTable.Add(45522);
        lootTable.Add(45527);
        lootTable.Add(45521);
        lootTable.Add(45656);
        lootTable.Add(45657);
        lootTable.Add(45658);
        return new LootTable(BossEnum.Yogg, lootTable);
    }
    private LootTable CreateLootTableYoggHard25()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45537);
        lootTable.Add(45536);
        lootTable.Add(45534);
        lootTable.Add(45535);
        lootTable.Add(45533);
        return new LootTable(BossEnum.YoggHard, lootTable);
    }

    private LootTable CreateLootTableFlameLeviathan10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45289);
        lootTable.Add(45291);
        lootTable.Add(45288);
        lootTable.Add(45283);
        lootTable.Add(45285);
        lootTable.Add(45292);
        lootTable.Add(45286);
        lootTable.Add(45284);
        lootTable.Add(45287);
        lootTable.Add(45282);
        return new LootTable(BossEnum.FlameLeviathan, lootTable);
    }

    private LootTable CreateLootTableFlameLeviathanHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45293);
        lootTable.Add(45300);
        lootTable.Add(45295);
        lootTable.Add(45297);
        lootTable.Add(45296);
        return new LootTable(BossEnum.FlameLeviathanHard, lootTable);
    }

    private LootTable CreateLootTableIgnis10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45317);
        lootTable.Add(45318);
        lootTable.Add(45312);
        lootTable.Add(45316);
        lootTable.Add(45321);
        lootTable.Add(45310);
        lootTable.Add(45313);
        lootTable.Add(45314);
        lootTable.Add(45311);
        lootTable.Add(45309);
        return new LootTable(BossEnum.Ignis, lootTable);
    }

    private LootTable CreateLootTableRazorscale10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45306);
        lootTable.Add(45302);
        lootTable.Add(45301);
        lootTable.Add(45307);
        lootTable.Add(45299);
        lootTable.Add(45305);
        lootTable.Add(45304);
        lootTable.Add(45303);
        lootTable.Add(45308);
        lootTable.Add(45298);
        return new LootTable(BossEnum.Razorscale, lootTable);
    }
    private LootTable CreateLootTableXT10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45694);
        lootTable.Add(45677);
        lootTable.Add(45686);
        lootTable.Add(45687);
        lootTable.Add(45679);
        lootTable.Add(45676);
        lootTable.Add(45680);
        lootTable.Add(45675);
        lootTable.Add(45685);
        lootTable.Add(45682);
        return new LootTable(BossEnum.XT, lootTable);
    }
    private LootTable CreateLootTableXTHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45869);
        lootTable.Add(45867);
        lootTable.Add(45871);
        lootTable.Add(45868);
        lootTable.Add(45870);
        return new LootTable(BossEnum.XTHard, lootTable);
    }
    private LootTable CreateLootTableIronCouncil10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45322);
        lootTable.Add(45423);
        lootTable.Add(45324);
        lootTable.Add(45378);
        lootTable.Add(45329);
        lootTable.Add(45333);
        lootTable.Add(45330);
        lootTable.Add(45418);
        lootTable.Add(45332);
        lootTable.Add(45331);
        return new LootTable(BossEnum.IronCouncil, lootTable);
    }
    private LootTable CreateLootTableIronCouncilHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45455);
        lootTable.Add(45447);
        lootTable.Add(45456);
        lootTable.Add(45449);
        lootTable.Add(45448);
        lootTable.Add(45506);
        return new LootTable(BossEnum.IronCouncilHard, lootTable);
    }
    private LootTable CreateLootTableAlgalon10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(46042);
        lootTable.Add(46045);
        lootTable.Add(46050);
        lootTable.Add(46043);
        lootTable.Add(46049);
        lootTable.Add(46044);
        lootTable.Add(46037);
        lootTable.Add(46039);
        lootTable.Add(46041);
        lootTable.Add(46047);
        lootTable.Add(46040);
        lootTable.Add(46048);
        lootTable.Add(46046);
        lootTable.Add(46038);
        lootTable.Add(46051);
        lootTable.Add(46052);
        return new LootTable(BossEnum.Algalon, lootTable);
    }
    private LootTable CreateLootTableKologarn10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45704);
        lootTable.Add(45701);
        lootTable.Add(45697);
        lootTable.Add(45698);
        lootTable.Add(45696);
        lootTable.Add(45699);
        lootTable.Add(45702);
        lootTable.Add(45703);
        lootTable.Add(45700);
        lootTable.Add(45695);
        return new LootTable(BossEnum.Kologarn, lootTable);
    }
    private LootTable CreateLootTableAuriaya10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45832);
        lootTable.Add(45865);
        lootTable.Add(45864);
        lootTable.Add(45709);
        lootTable.Add(45711);
        lootTable.Add(45712);
        lootTable.Add(45708);
        lootTable.Add(45866);
        lootTable.Add(45707);
        lootTable.Add(45713);
        return new LootTable(BossEnum.Auriaya, lootTable);
    }
    private LootTable CreateLootTableHodir10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45873);
        lootTable.Add(45464);
        lootTable.Add(45874);
        lootTable.Add(45458);
        lootTable.Add(45872);
        return new LootTable(BossEnum.Hodir, lootTable);
    }
    private LootTable CreateLootTableHodirHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45888);
        lootTable.Add(45876);
        lootTable.Add(45886);
        lootTable.Add(45887);
        lootTable.Add(45877);
        lootTable.Add(45786);
        lootTable.Add(45650);
        lootTable.Add(45651);
        lootTable.Add(45652);
        return new LootTable(BossEnum.HodirHard, lootTable);
    }
    private LootTable CreateLootTableThorim10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45893);
        lootTable.Add(45927);
        lootTable.Add(45894);
        lootTable.Add(45895);
        lootTable.Add(45892);
        return new LootTable(BossEnum.Thorim, lootTable);
    }
    private LootTable CreateLootTableThorimHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45928);
        lootTable.Add(45933);
        lootTable.Add(45931);
        lootTable.Add(45929);
        lootTable.Add(45930);
        lootTable.Add(45784);
        lootTable.Add(45659);
        lootTable.Add(45660);
        lootTable.Add(45661);
        return new LootTable(BossEnum.ThorimHard, lootTable);
    }
    private LootTable CreateLootTableFreya10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45940);
        lootTable.Add(45941);
        lootTable.Add(45935);
        lootTable.Add(45936);
        lootTable.Add(45934);
        return new LootTable(BossEnum.Freya, lootTable);
    }
    private LootTable CreateLootTableFreyaHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45943);
        lootTable.Add(45945);
        lootTable.Add(45946);
        lootTable.Add(45947);
        lootTable.Add(45294);
        lootTable.Add(45788);
        lootTable.Add(45644);
        lootTable.Add(45645);
        lootTable.Add(45646);
        lootTable.Add(46110);
        return new LootTable(BossEnum.FreyaHard, lootTable);
    }
    private LootTable CreateLootTableMimiron10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45973);
        lootTable.Add(45976);
        lootTable.Add(45974);
        lootTable.Add(45975);
        lootTable.Add(45972);
        return new LootTable(BossEnum.Mimiron, lootTable);
    }
    private LootTable CreateLootTableMimironHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(45993);
        lootTable.Add(45989);
        lootTable.Add(45982);
        lootTable.Add(45988);
        lootTable.Add(45990);
        lootTable.Add(45787);
        lootTable.Add(45647);
        lootTable.Add(45648);
        lootTable.Add(45649);
        return new LootTable(BossEnum.MimironHard, lootTable);
    }
    private LootTable CreateLootTableVezax10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(46014);
        lootTable.Add(46013);
        lootTable.Add(46012);
        lootTable.Add(46009);
        lootTable.Add(46346);
        lootTable.Add(45997);
        lootTable.Add(46008);
        lootTable.Add(46015);
        lootTable.Add(46010);
        lootTable.Add(46011);
        lootTable.Add(45996);
        return new LootTable(BossEnum.Vezax, lootTable);
    }
    private LootTable CreateLootTableVezaxHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(46032);
        lootTable.Add(46034);
        lootTable.Add(46036);
        lootTable.Add(46035);
        lootTable.Add(46033);
        return new LootTable(BossEnum.VezaxHard, lootTable);
    }
    private LootTable CreateLootTableYogg10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(46030);
        lootTable.Add(46019);
        lootTable.Add(46028);
        lootTable.Add(46022);
        lootTable.Add(46021);
        lootTable.Add(46024);
        lootTable.Add(46016);
        lootTable.Add(46031);
        lootTable.Add(46025);
        lootTable.Add(46018);
        lootTable.Add(45635);
        lootTable.Add(45636);
        lootTable.Add(45637);
        return new LootTable(BossEnum.Yogg, lootTable);
    }
    private LootTable CreateLootTableYoggHard10()
    {
        HashSet<int> lootTable = new HashSet<int>();
        lootTable.Add(46068);
        lootTable.Add(46095);
        lootTable.Add(46096);
        lootTable.Add(46097);
        lootTable.Add(46067);
        return new LootTable(BossEnum.YoggHard, lootTable);
    }





}
