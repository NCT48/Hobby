using DominionLib.Card;
using DominionLib.Field;

namespace DominionLib.Strategy;

public record OutPutData(int Trun, int ActionCount);

public static partial class Strategy
{
    private static readonly FieldData field = FieldData.Instance;

    public static readonly IReadOnlyList<string> StrategyList = new List<string>
    {
        nameof(SmithySteroid),
    };

    public static IEnumerable<OutPutData> GetResults(string strategyName)
    {
        foreach (var _ in Enumerable.Repeat(0, 1000))
        {
            yield return ExecuteStrategy(strategyName);
        }
    }

    private static OutPutData ExecuteStrategy(string strategyName) => strategyName switch
    {
        nameof(SmithySteroid) => SmithySteroid(),
        _ => throw new InvalidOperationException(nameof(strategyName)),
    };
}
