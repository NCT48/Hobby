using DominionLib.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionLib.Field;

internal class FieldData
{
    public static readonly FieldData Instance = new();

    private List<ICard> hands = new();
    private List<ICard> drops = new();
    private List<ICard> actionArea = new();
    private List<ICard> deck = new();
    private List<ICard> remove = new();
    private List<ICard> duration = new();
    public IReadOnlyList<ICard> Hands => hands;
    public IReadOnlyList<ICard> Drops => drops;
    public IReadOnlyList<ICard> ActionArea => actionArea;
    public IReadOnlyList<ICard> Deck => deck;
    public IReadOnlyList<ICard> Remove => remove;
    public IReadOnlyList<ICard> Duration => duration;

    public int OnceMoney { get; set; }

    public void NewGame()
    {
        hands = new();
        drops = new();
        actionArea = new();
        deck = Enumerable.Repeat<ICard>(BasicList.Copper, 7).Concat(Enumerable.Repeat(BasicList.Estate, 3)).OrderBy(x => Guid.NewGuid()).ToList();
        remove = new();
        duration = new();
        Draw(5);
    }

    public void Draw(int count)
    {
        if (deck.Count >= count)
        {
            hands.AddRange(deck.Take(count));
            deck.RemoveRange(0, count);
            return;
        }
        var remainingCount = count - deck.Count;
        hands.AddRange(deck);
        deck = drops.OrderBy(x => Guid.NewGuid()).ToList();
        drops.Clear();
        if (deck.Count >= remainingCount)
        {
            hands.AddRange(deck.Take(remainingCount));
            deck.RemoveRange(0, remainingCount);
            return;
        }
        hands.AddRange(deck);
        deck.Clear();
    }

    public void NextTurn()
    {
        drops.AddRange(hands);
        duration.AddRange(actionArea.Where(x => x is IDuration));
        drops.AddRange(actionArea.Where(x => x is not IDuration));

        hands.Clear();
        actionArea.Clear();

        OnceMoney = 0;
        Draw(5);
        //duration.AddRange
    }

    public void AllUse()
    {
        actionArea.AddRange(hands);
        hands.Clear();
    }

    public int CountMoney() => actionArea.OfType<ITreasure>().Sum(x => x.Money) + OnceMoney;

    public void GetCard(ICard card) => drops.Add(card);
}
