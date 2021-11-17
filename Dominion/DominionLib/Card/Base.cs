using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionLib.Card;

public enum ExpansionType
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

public interface ICard
{
    string Name { get; }
    int Cost { get; }
    ExpansionType Expansion { get; }
}

public interface ITreasure
{
    int Money { get; }
}

public interface IVictory
{
    int Point { get; }
}

public interface IAction
{
    void Action();
}

public interface IDuration
{
    void Duration();
}
