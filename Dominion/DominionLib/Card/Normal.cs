using DominionLib.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionLib.Card;

internal class NormalList
{
    public static readonly Smithy Smithy = new();
}

internal class Smithy : ICard, IAction
{
    public string Name => "鍛冶屋";
    public int Cost => 3;
    public ExpansionType Expansion => ExpansionType.Normal;
    public void Action() => FieldData.Instance.Draw(3);
}
