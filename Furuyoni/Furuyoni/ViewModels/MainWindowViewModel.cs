using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Furuyoni.Model;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace Furuyoni.ViewModels
{
    public class MainWindowViewModel : BindableBase
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
        public IEnumerable<MainViewCard> Cards { get; private set; }
        public IEnumerable<MainViewCard> MasterCards { get; }

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

        private List<CheckBoxSource> originalOwnerFilter;
        private List<CheckBoxSource> originalCategoryFilter;
        private List<CheckBoxSource> originalMainFilter;
        private List<CheckBoxSource> originalSubFilter;

        public List<CheckBoxSource> EditOwnerFilter { get; private set; }
        public List<CheckBoxSource> EditCategoryFilter { get; private set; }
        public List<CheckBoxSource> EditMainFilter { get; private set; }
        public List<CheckBoxSource> EditSubFilter { get; private set; }

        public MainWindowViewModel(ICardList iCards)
        {
            MasterCards = iCards.Cards.Select(x => new MainViewCard(x));
            Cards = MasterCards.AsEnumerable();

            originalOwnerFilter = MasterCards.Select(x => x.Owner).Distinct().Select(x => new CheckBoxSource(x, true)).ToList();
            originalCategoryFilter = MasterCards.Select(x => x.Category).Distinct().Select(x => new CheckBoxSource(x, true)).ToList();
            originalMainFilter = MasterCards.Select(x => x.Main).Distinct().Select(x => new CheckBoxSource(x, true)).ToList();
            originalSubFilter = MasterCards.Select(x => x.Sub).Distinct().Select(x => new CheckBoxSource(x, true)).ToList();
        }

        public InteractionRequest<INotification> ShowViewRequest { get; } = new InteractionRequest<INotification>();

        private DelegateCommand<Type> _ShowViewCommand;
        public DelegateCommand<Type> ShowViewCommand => _ShowViewCommand ??= new DelegateCommand<Type>(ShowView);
        public void ShowView(Type windowType)
        {
            EditOwnerFilter = originalOwnerFilter.Select(x => new CheckBoxSource(x.Text, x.IsChecked)).ToList();
            EditCategoryFilter = originalCategoryFilter.Select(x => new CheckBoxSource(x.Text, x.IsChecked)).ToList();
            EditMainFilter = originalMainFilter.Select(x => new CheckBoxSource(x.Text, x.IsChecked)).ToList();
            EditSubFilter = originalSubFilter.Select(x => new CheckBoxSource(x.Text, x.IsChecked)).ToList();

            ShowViewRequest.Raise(new Notification { Content = this });
        }

        public InteractionRequest<INotification> CloseWindowRequest { get; } = new InteractionRequest<INotification>();

        private DelegateCommand<string> _CloseWindowCommand;
        public DelegateCommand<string> CloseWindowCommand => _CloseWindowCommand ??= new DelegateCommand<string>(CloseWindow);

        private void CloseWindow(string filterEnable)
        {
            if (filterEnable == "True")
            {
                originalOwnerFilter = EditOwnerFilter;
                originalCategoryFilter = EditCategoryFilter;
                originalMainFilter = EditMainFilter;
                originalSubFilter = EditSubFilter;
                Cards = MasterCards.Where(Filtering);
                RaisePropertyChanged(nameof(Cards));
            }
            CloseWindowRequest.Raise(new Notification());
        }

        private bool Filtering(MainViewCard card)
        {
            return FilterSearch(originalOwnerFilter, card.Owner) &&
                   FilterSearch(originalCategoryFilter, card.Category) &&
                   FilterSearch(originalMainFilter, card.Main) &&
                   FilterSearch(originalSubFilter, card.Sub);
        }

        private bool FilterSearch(IEnumerable<CheckBoxSource> checks, string key)
            => checks.Any(x => x.IsChecked && x.Text == key);

        private DelegateCommand<string> _EditCheckBoxCommand;
        public DelegateCommand<string> EditCheckBoxCommand => _EditCheckBoxCommand ??= new DelegateCommand<string>(EditCheckBox);

        private void EditCheckBox(string filterName)
        {
            if (filterName == "Owner")
            {
                EditOwnerFilter = EditCheckBoxSource(EditOwnerFilter).ToList();
                RaisePropertyChanged(nameof(EditOwnerFilter));
            }
            if (filterName == "Category")
            {
                EditCategoryFilter = EditCheckBoxSource(EditCategoryFilter).ToList();
                RaisePropertyChanged(nameof(EditCategoryFilter));
            }
            if (filterName == "Main")
            {
                EditMainFilter = EditCheckBoxSource(EditMainFilter).ToList();
                RaisePropertyChanged(nameof(EditMainFilter));
            }
            if (filterName == "Sub")
            {
                EditSubFilter = EditCheckBoxSource(EditSubFilter).ToList();
                RaisePropertyChanged(nameof(EditSubFilter));
            }
        }

        private IEnumerable<CheckBoxSource> EditCheckBoxSource(IEnumerable<CheckBoxSource> checkBoxSources)
        {
            var setValue = !checkBoxSources.All(x => x.IsChecked);
            foreach (var cb in checkBoxSources)
            {
                cb.IsChecked = setValue;
                yield return cb;
            }
        }
    }
}
