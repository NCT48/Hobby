using Furuyoni.Model;

namespace Furuyoni.ViewModels.MainWindow
{
    public class MainViewCard
    {
        public MainViewCard(Card card)
        {
            Name = card.Name;
            Owner = card.Owner;
            Category = card.Category.GetType().Name;
            Main = card.Main.GetType().Name;
            Sub = card.Sub.GetType().Name;
            Text = card.Text;
        }

        public string Name { get; set; }
        public string Owner { get; set; }
        public string Category { get; set; }
        public string Main { get; set; }
        public string Sub { get; set; }
        public string Text { get; set; }
    }

    public class CheckBoxSource
    {
        public string Text { get; }
        public bool IsChecked { get; set; }

        public CheckBoxSource(string text, bool isChecked)
        {
            Text = text;
            IsChecked = isChecked;
        }
    }
}
