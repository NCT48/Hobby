using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DominionLib.Strategy;
using LiveCharts;
using LiveCharts.Wpf;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;

namespace DominionAnalyzer.ViewModel;

public class MainWindowViewModel : BindableBase
{
    public static IReadOnlyList<string> StrategyList => Strategy.StrategyList;
    public string SelectedStrategy { get; set; } = string.Empty;
    public Visibility GraphVisiblity { get; private set; } = Visibility.Hidden;
    public SeriesCollection SeriesCollection { get; private set; } = new SeriesCollection();
    public IReadOnlyList<string> Labels { get; private set; } = new List<string>();

    private DelegateCommand? drawGraphCommand;
    public DelegateCommand DrawGraphCommand => drawGraphCommand ??= new DelegateCommand(DrawGraph);
    private void DrawGraph()
    {
        GraphVisiblity = Visibility.Visible;
        RaisePropertyChanged(nameof(GraphVisiblity));

        var histogram = new SortedList<int, int>();
        var min = int.MaxValue;
        var max = int.MinValue;
        var sum = 0.0;
        var count = 0;

        var rslt = Strategy.GetResults(SelectedStrategy).ToArray();
        foreach (var turn in rslt.Select(x => x.Trun))
        {
            if (min > turn)
                min = turn;
            if (max < turn)
                max = turn;
            sum += turn;
            count++;
            if (!histogram.ContainsKey(turn))
                histogram.Add(turn, 0);

            histogram[turn]++;
        }
        var average = sum / count;
        var stdDev = rslt.Sum(x => Math.Pow(x.Trun - average, 2)) / count;

        SeriesCollection = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = SelectedStrategy,
                Values = new ChartValues<int>(histogram.Select(x => x.Value)),
            },
        };
        Labels = histogram.Select(x => x.Key.ToString()).ToList();

        RaisePropertyChanged(nameof(SeriesCollection));
        RaisePropertyChanged(nameof(Labels));
    }
}
