using System;
using System.Collections.Generic;
using System.Linq;

using Models.Master;
namespace ExtendLinq
{
    public static class StandardDeviation
    {
        public static (double average, double deviation) AverageDeviation(this IEnumerable<double> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var ave = 0.0;
            var sum = 0.0;
            var count = 0L;
            foreach (var item in source)
            {
                checked
                {
                    count += 1L;
                }
                sum += item;
            }
            if (count <= 0L)
            {
                throw new InvalidOperationException("NoElements");
            }
            ave = sum / count;
            return (ave, Math.Sqrt(source.Sum(y => Math.Pow(y, 2) - Math.Pow(ave, 2)) / count));
        }

        public static double Deviation(this IEnumerable<double> source)
        {
            var (_, dev) = AverageDeviation(source);
            return dev;
        }

        public static (double average, double deviation) AverageDeviation<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            return source.Where(x => selector(x) != 0).Select(selector).AverageDeviation();
        }

        public static double Deviation<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            return source.Where(x => selector(x) != 0).Select(selector).Deviation();
        }

        public static IEnumerable<double> Score(this IEnumerable<double> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            IEnumerable<double> score()
            {
                var ave = 0.0;
                var sum = 0.0;
                var count = 0;
                foreach (var item in source)
                {
                    count++;
                    sum += item;
                }
                if (count == 0)
                {
                    throw new InvalidOperationException("NoElements");
                }

                ave = sum / count;
                var dev = Math.Sqrt(source.Sum(y => Math.Pow(y, 2) - Math.Pow(ave, 2)) / count);
                foreach (var item in source)
                {
                    yield return 10 * (item - ave) / dev + 50;
                }
            }

            return score();
        }

        public static IEnumerable<double> Score<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            return source.Select(selector).Score();
        }
    }

    public static class DevitationIDOL
    {
        public static IEnumerable<(string Name, double Score)> Similarity(this IEnumerable<IDOLDeviation> source, IDOLDeviation deviation)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (deviation == null)
            {
                yield break;
            }
            foreach (var item in source)
            {
                static double Eva(double score, double target) => score == 0 ? 0 : Math.Pow(score - target, 2);
                var value = 0.0;
                value += Eva(deviation.HeightScore, item.HeightScore);
                value += Eva(deviation.WeightScore, item.WeightScore);
                value += Eva(deviation.BustScore, item.BustScore);
                value += Eva(deviation.WaistScore, item.WaistScore);
                value += Eva(deviation.HipScore, item.HipScore);
                yield return (item.Name, Math.Round(value, 2, MidpointRounding.AwayFromZero));
            }
        }

        public static IEnumerable<IDOLDeviation> ToDevitation(this IEnumerable<IDOLView> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var (ageAverage, ageDeviation) = source.AverageDeviation(x => x.Age);
            var (heightAverage, heightDeviation) = source.AverageDeviation(x => x.Height);
            var (weightAverage, weightDeviation) = source.AverageDeviation(x => x.Weight);
            var (bustAverage, bustDeviation) = source.AverageDeviation(x => x.Bust);
            var (waistAverage, waistDeviation) = source.AverageDeviation(x => x.Waist);
            var (hipAverage, hipDeviation) = source.AverageDeviation(x => x.Hip);
            var (bmiAverage, bmiDeviation) = source.AverageDeviation(x => x.BMI);
            var (underAverage, underDeviation) = source.AverageDeviation(x => x.Under);
            var (diffAverage, diffDeviation) = source.AverageDeviation(x => x.Diffe);

            IEnumerable<IDOLDeviation> deviations()
            {
                foreach (var item in source)
                {
                    yield return new IDOLDeviation {
                        Name = item.Name,
                        Phonetic = item.Phonetic,
                        AgeScore = score(item.Age, ageAverage, ageDeviation),
                        HeightScore = score(item.Height, heightAverage, heightDeviation),
                        WeightScore = score(item.Weight, weightAverage, weightDeviation),
                        BustScore = score(item.Bust, bustAverage, bustDeviation),
                        WaistScore = score(item.Waist, waistAverage, waistDeviation),
                        HipScore = score(item.Hip, hipAverage, hipDeviation),
                        BMIScore = score(item.BMI, bmiAverage, bmiDeviation),
                        UnderScore = score(item.Under, underAverage, underDeviation),
                        DiffScore = score(item.Diffe, diffAverage, diffDeviation),
                    };
                }
            }

            static double score(double value, double avg, double dev) =>
                value == 0 ? 0 : Math.Round((10 * (value - avg) / dev) + 50, 2, MidpointRounding.AwayFromZero);

            return deviations().OrderBy(x => x.TotalScore);
        }
    }

    public static class RandomLinq
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(_ => Guid.NewGuid());
        }

        public static T Random<T>(this IEnumerable<T> source)
        {
            var index = Guid.NewGuid().GetHashCode() % source.Count();
            return source.ElementAt(Math.Abs(index));
        }
    }
}