using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominionLib.Card;

namespace DominionLib.Strategy;

public static partial class Strategy
{
    public static OutPutData SmithySteroid()
    {
        field.NewGame();

        var smithyCount = 0;
        var provinceCount = 0;
        var goldCount = 0;

        var turn = 0;
        var actionCount = 0;

        while (provinceCount != 4)
        {
            turn++;
            if (field.Hands.Any(x => x is Smithy))
            {
                actionCount++;
                NormalList.Smithy.Action();
            }
            field.AllUse();
            var money = field.CountMoney();

            if (money >= 8)
            {
                if (goldCount == 0)
                {
                    goldCount++;
                    field.GetCard(BasicList.Gold);
                }
                else
                {
                    provinceCount++;
                    field.GetCard(BasicList.Province);
                }
            }
            else if (money >= 6)
                field.GetCard(BasicList.Gold);
            else if (money >= 4)
                if (smithyCount == 0)
                {
                    smithyCount++;
                    field.GetCard(NormalList.Smithy);
                }
                else
                    field.GetCard(BasicList.Silver);
            else if (money >= 3)
                field.GetCard(BasicList.Silver);

            field.NextTurn();
        }
        return new OutPutData(turn, actionCount);
    }
}

