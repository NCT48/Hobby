using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionLib.Card;

internal class BasicList
{
    public static readonly Copper Copper = new();
    public static readonly Silver Silver = new();
    public static readonly Gold Gold = new();
    public static readonly Estate Estate = new();
    public static readonly Platinum Platinum = new();
    public static readonly Duchy Duchy = new();
    public static readonly Province Province = new();
    public static readonly Colony Colony = new();
    public static readonly Cures Cures = new();
}

internal class Copper : ICard, ITreasure
{
    public string Name => "銅貨";
    public int Cost => 0;
    public ExpansionType Expansion => ExpansionType.Normal;
    public int Money => 1;
}
internal class Silver : ICard, ITreasure
{
    public string Name => "銀貨";
    public int Cost => 3;
    public ExpansionType Expansion => ExpansionType.Normal;
    public int Money => 2;
}
internal class Gold : ICard, ITreasure
{
    public string Name => "金貨";
    public int Cost => 6;
    public ExpansionType Expansion => ExpansionType.Normal;
    public int Money => 3;
}
internal class Platinum : ICard, ITreasure
{
    public string Name => "プラチナ貨";
    public int Cost => 9;
    public ExpansionType Expansion => ExpansionType.Prosperity;
    public int Money => 5;
}
internal class Estate : ICard, IVictory
{
    public string Name => "屋敷";
    public int Cost => 2;
    public ExpansionType Expansion => ExpansionType.Normal;
    public int Point => 1;
}
internal class Duchy : ICard, IVictory
{
    public string Name => "公領";
    public int Cost => 5;
    public ExpansionType Expansion => ExpansionType.Normal;
    public int Point => 3;
}
internal class Province : ICard, IVictory
{
    public string Name => "属州";
    public int Cost => 8;
    public ExpansionType Expansion => ExpansionType.Normal;
    public int Point => 6;
}
internal class Colony : ICard, IVictory
{
    public string Name => "植民地";
    public int Cost => 10;
    public ExpansionType Expansion => ExpansionType.Prosperity;
    public int Point => 11;
}
internal class Cures : ICard
{
    public string Name => "呪い";
    public int Cost => 0;
    public ExpansionType Expansion => ExpansionType.Normal;
}
