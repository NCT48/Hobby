using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Furuyoni.Model
{
    public class RootObject
    {
        public List<CardJson> Cards { get; set; }
    }

    public class CardJson
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Category { get; set; }
        public string Main { get; set; }
        public string Sub { get; set; }
        public string Text { get; set; }
        public string Cost { get; set; }
        public string Range { get; set; }
        public string Damage { get; set; }
        public int Charge { get; set; }

        public CardJson()
        {

        }

        public CardJson(Card card)
        {
            Name = card.Name;
            Owner = card.Owner;
            Text = card.Text;

            Category = card.Category.GetType().Name;
            Main = card.Main.GetType().Name;
            Sub = card.Sub.GetType().Name;

            if (card.Category is Special s)
            {
                Cost = s.Cost;
            }

            switch (card.Main)
            {
                case Atack a:
                    Range = string.Join(",", a.Range);
                    Damage = a.AuraDamage + "/" + a.LifeDamage;
                    break;
                case Grant g:
                    Charge = g.Charge;
                    break;
            }
        }
    }

    public interface ICardList
    {
        IReadOnlyList<Card> Cards { get; }
    }

    public class CardList : ICardList
    {
        public IReadOnlyList<Card> Cards { get; } = ReadFuruyoniJson();
        private static IReadOnlyList<Card> ReadFuruyoniJson()
        {
            using var sr = new StreamReader(@"Resource\CardList.json", Encoding.UTF8);
            var rootObject = JsonConvert.DeserializeObject<RootObject>(sr.ReadToEnd());
            return rootObject.Cards.Select(x => new Card(x)).ToList();
        }
    }

    public class Card
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public CardType Category { get; set; }
        public CardType Main { get; set; }
        public CardType Sub { get; set; }
        public string Text { get; set; }

        public Card(CardJson cj)
        {
            Name = cj.Name;
            Owner = cj.Owner;
            Text = cj.Text;
            Category = CreateInstance<CardType>(cj, cj.Category);
            Main = CreateInstance<CardType>(cj, cj.Main);
            Sub = CreateInstance<CardType>(cj, cj.Sub);
        }

        private T CreateInstance<T>(CardJson cj, string str)
        {
            var type = Type.GetType($"Furuyoni.Model.{str}", true);
            var args = new object[] { cj };
            return (T)Activator.CreateInstance(type, args);
        }
    }

    public abstract class CardType { }

    public class Normal : CardType { public Normal(CardJson _) { } }

    public class Poison : CardType { public Poison(CardJson _) { } }

    public class TransForm : CardType { public TransForm(CardJson _) { } }

    public class Special : CardType
    {
        public string Cost { get; set; }
        public Special(CardJson cj) => Cost = cj.Cost;
    }

    public class Atack : CardType
    {
        public List<int> Range { get; set; }
        public string AuraDamage { get; set; }
        public string LifeDamage { get; set; }

        public Atack(CardJson cj)
        {
            Range = cj.Range.Split(',').Select(x => int.TryParse(x, out var value) ? value : -1).ToList();
            var damage = cj.Damage.Split('/');
            AuraDamage = damage[0];
            LifeDamage = damage[1];
        }
    }

    public class Action : CardType { public Action(CardJson _) { } }

    public class Grant : CardType
    {
        public int Charge { get; set; }
        public Grant(CardJson cj) => Charge = cj.Charge;
    }

    public class Unknown : CardType { public Unknown(CardJson _) { } }
    public class None : CardType { public None(CardJson _) { } }
    public class Reaction : CardType { public Reaction(CardJson _) { } }
    public class Fullpower : CardType { public Fullpower(CardJson _) { } }
}
