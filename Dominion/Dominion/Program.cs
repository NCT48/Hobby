using DominionLib.Card;
using DominionLib.Field;
using DominionLib.Strategy;

namespace Dominion;

public static class DominionProgram
{
    static void Main(string[] args)
    {
        var rsltList = new List<OutPutData>();
        foreach (var _ in Enumerable.Repeat(0, 1000))
            rsltList.Add(Strategy.SmithySteroid());

        using var sw = new StreamWriter(@"rslt.csv");
        sw.WriteLine("Turn");
        foreach (var outPutData in rsltList)
            sw.WriteLine(outPutData.Turn);
    }
}
