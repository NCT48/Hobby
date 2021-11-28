using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionLib.Card;

internal enum ExpansionType
{
    Normal,
    Intrigue,
    Seaside,
    Alchemy,
    Prosperity,
    Cornucopia,
    Hinterlands,
    DarkAges,
    Guilds,
    Adventures,
    Empires,
    Nocturne,
    Renaissance,
    Menagerie,
    Allies,
    Promos,
}

internal interface ICard
{
    string Name { get; }
    int Cost { get; }
    ExpansionType Expansion { get; }
}

internal interface ITreasure
{
    int Money { get; }
}

internal interface IVictory
{
    int Point { get; }
}

internal interface IAction
{
    void Action();
}

internal interface IDuration
{
    void Duration();
}
