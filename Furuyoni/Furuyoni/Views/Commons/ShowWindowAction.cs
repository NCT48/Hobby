using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Prism.Interactivity.InteractionRequest;

namespace Furuyoni.Views.Commons
{
    public class ShowWindowAction : TriggerAction<DependencyObject>
    {
        public Type WindowType
        {
            get { return (Type)GetValue(WindowTypeProperty); }
            set { SetValue(WindowTypeProperty, value); }
        }

        public bool IsModal
        {
            get { return (bool)GetValue(IsModalProperty); }
            set { SetValue(IsModalProperty, value); }
        }

        public static readonly DependencyProperty WindowTypeProperty =
            DependencyProperty.Register(nameof(WindowType), typeof(Type), typeof(ShowWindowAction), new UIPropertyMetadata(null));

        public static readonly DependencyProperty IsModalProperty =
            DependencyProperty.Register(nameof(IsModalProperty), typeof(bool), typeof(ShowWindowAction), new UIPropertyMetadata(null));

        protected override void Invoke(object parameter)
        {
            if (!(parameter is InteractionRequestedEventArgs args))
            {
                return;
            }

            if (!(args.Context is Notification context))
            {
                return;
            }

            if (IsModal)
            {
                CreateOrActiveWindow(context).ShowDialog();
            }
            else
            {
                CreateOrActiveWindow(context).Show();
            }
        }

        private Window CreateOrActiveWindow(Notification n)
        {
            if (WindowType == null)
            {
                return new Window { Title = n.Title, DataContext = n.Content };
            }

            var window = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.Title == n.Title);
            if (window == null)
            {
                window = WindowType.GetConstructor(Type.EmptyTypes).Invoke(null) as Window;
                if (n.Title != null)
                {
                    window.Title = n.Title;
                }
                if (n.Content != null)
                {
                    window.DataContext = n.Content;
                }
            }
            else
            {
                window.Activate();
            }

            return window;
        }
    }
}
